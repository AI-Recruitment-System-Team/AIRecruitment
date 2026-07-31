using AIRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AIRecruitment.BLL.DTOs.Job;
using AIRecruitment.BLL.Interfaces;
using AIRecruitment.DAL.Context;
using AutoMapper;
using AIRecruitment.BLL.DTOs.Dashboard;

namespace AIRecruitment.BLL.Services
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public JobService(
            ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateJobAsync(CreateJobDto dto, string recruiterId)
        {
            var job = _mapper.Map<Job>(dto);

            job.RecruiterId = recruiterId;
            job.CreatedAt = DateTime.UtcNow;

            await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GetJobDto>> GetAllJobsAsync(
            string? keyword,
            decimal? minSalary,
            string? skill)
        {
            var query = _context.Jobs
                .Include(j => j.Company)
                .Include(j => j.JobSkills)
                    .ThenInclude(js => js.Skill)
                .Include(j => j.Applications)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(j =>
                j.Title.Contains(keyword) ||
                j.Description.Contains(keyword) ||
                j.Company.Name.Contains(keyword));
            }

            if (minSalary.HasValue)
            {
                query = query.Where(j => j.MinSalary >= minSalary.Value);
            }

            if (!string.IsNullOrWhiteSpace(skill))
            {
                query = query.Where(j =>
                j.JobSkills.Any(js => js.Skill.Name == skill));
            }

            query = query.Where(j => j.Status == "Open");
            var jobs = await query.ToListAsync();

            return _mapper.Map<List<GetJobDto>>(jobs);
        }

        public async Task<GetJobDto?> GetJobByIdAsync(int id)
        {
            var job = await _context.Jobs
                .Include(j => j.Company)
                .Include(j => j.JobSkills)
                    .ThenInclude(js => js.Skill)
                .FirstOrDefaultAsync(j => j.Id == id);

            if (job == null)
                return null;

            return _mapper.Map<GetJobDto>(job);
        }

        public async Task UpdateJobAsync(int id, UpdateJobDto dto)
        {
            var job = await _context.Jobs.FindAsync(id);

            if (job == null)
                throw new Exception("Job not found. ");

            _mapper.Map(dto, job);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteJobeAsync(int id)
        {
            var job = await _context.Jobs.FindAsync(id);

            if (job == null)
                throw new Exception("Job not found. ");

            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();

        }

        public async Task<List<RecruiterJobDto>> GetRecruiterJobsAsync(string recruiterId)
        {
            var jobs = await _context.Jobs
                .Include(j => j.Company)
                .Where(j => j.RecruiterId == recruiterId)
                .OrderByDescending(js => js.CreatedAt)
                .ToListAsync();

            return _mapper.Map<List<RecruiterJobDto>>(jobs);
        }

        public async Task ToggleJobStatusAsync(int jobId)
        {
            var job = await _context.Jobs.FindAsync(jobId);

            if (job == null)
                throw new Exception("Job not found.");

            job.Status = job.Status == "Open"
                ? "Closed"
                : "Open";

            await _context.SaveChangesAsync();
        }

        //Returns recruiter dashboard statistics and recent activity
        public async Task<RecruiterDashboardDto> GetRecruiterDashboardAsync(string recruiterId)
        {
            var activeJobs = await _context.Jobs
                .CountAsync(j => j.RecruiterId == recruiterId &&
                                 j.Status == "Open");

            var totalApplicants = await _context.Applications
                .CountAsync(a => a.Job.RecruiterId == recruiterId);

            var aiShortlisted = await _context.AIAnalyses
                .CountAsync(a => a.MatchScore >= 85 &&
                                 a.Application.Job.RecruiterId == recruiterId);

            var scheduledInterviews = await _context.Interviews
                .CountAsync(i => i.Application.Job.RecruiterId == recruiterId);

            var recentApplications = await _context.Applications
                .Include(a => a.CandidateProfile)
                    .ThenInclude(cp => cp.Candidate)
                .Include(a => a.Job)
                .Include(a => a.AIAnalysis)
                .Where(a => a.Job.RecruiterId == recruiterId)
                .OrderByDescending(a => a.AppliedAt)
                .Take(5)
                .ToListAsync();

            var interviewList = await _context.Interviews
                .Include(i => i.Application)
                    .ThenInclude(a => a.CandidateProfile)
                        .ThenInclude(cp => cp.Candidate)
                .Include(i => i.Application)
                    .ThenInclude(a => a.Job)
                .Where(i => i.Application.Job.RecruiterId == recruiterId)
                .OrderBy(i => i.InterviewDate)
                .Take(5)
                .ToListAsync();

            return new RecruiterDashboardDto
            {
                ActiveJobs = activeJobs,
                TotalApplicants = totalApplicants,
                AIShortlisted = aiShortlisted,
                ScheduledInterviews = scheduledInterviews,

                RecentApplications = recentApplications.Select(a => new RecentApplicationDto
                {
                    ApplicationId = a.Id,
                    CandidateName = $"{a.CandidateProfile.Candidate.FirstName} {a.CandidateProfile.Candidate.LastName}",
                    JobTitle = a.Job.Title,
                    MatchScore = a.AIAnalysis != null ? a.AIAnalysis.MatchScore : 0,
                    AppliedAt = a.AppliedAt
                }).ToList(),

                ScheduledInterviewsList = interviewList.Select(i => new ScheduledInterviewDto
                {
                    InterviewId = i.Id,
                    CandidateName = $"{i.Application.CandidateProfile.Candidate.FirstName} {i.Application.CandidateProfile.Candidate.LastName}",
                    JobTitle = i.Application.Job.Title,
                    InterviewDate = i.InterviewDate
                }).ToList()
            };
        }
    }
}