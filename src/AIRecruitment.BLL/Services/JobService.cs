using AIRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AIRecruitment.BLL.DTOs.Job;
using AIRecruitment.BLL.Interfaces;
using AIRecruitment.DAL.Context;
using AutoMapper;

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
            var query =  _context.Jobs
                .Include(j => j.Company)
                .Include(j => j.JobSkills)
                    .ThenInclude(js => js.Skill)
                .Include(j => j.Applications)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(j => 
                j.Title.Contains(keyword)||
                j.Description.Contains(keyword)||
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

            if(job == null)
            return null;
            
            return _mapper.Map<GetJobDto>(job);
        }

        public async Task UpdateJobAsync(int id, UpdateJobDto dto)
        {
            var job = await _context.Jobs.FindAsync(id);

            if(job == null)
                throw new Exception("Job not found. ");

            _mapper.Map(dto, job);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteJobeAsync(int id)
        {      
            var job = await _context.Jobs.FindAsync(id);

            if(job == null)
                throw new Exception("Job not found. ");
            
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
        
        }
    }
}