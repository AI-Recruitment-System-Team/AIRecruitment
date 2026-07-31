using AIRecruitment.BLL.DTOs.Application;
using AIRecruitment.DAL.Context;
using AIRecruitment.Domain.Entities;
using AIRecruitment.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
namespace AIRecruitment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApplicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Apply(CreateApplicationDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var candidate = await _context.CandidateProfiles
                .FirstOrDefaultAsync(c => c.CandidateId == userId);

            if (candidate == null)
                return NotFound("Candidate profile not found. ");

            var job = await _context.Jobs.FindAsync(dto.JobId);

            if (job == null)
                return NotFound("Job not found.");
            
            if (job.Status != "Open")
            {
                return BadRequest("This job is closed.");
            }

            var alreadyApplied = await _context.Applications.AnyAsync(a => 
            a.CandidateProfileId == candidate.Id &&
            a.JobId == dto.JobId);

            if (alreadyApplied)
                return BadRequest("You have already applied for this job. ");

            var resume = await _context.Resumes
                .FirstOrDefaultAsync(r => 
                    r.Id == dto.ResumeId && 
                    r.CandidateProfileId == candidate.Id);

            if (resume == null)
                return BadRequest("Invalid resume.");

            var application = new Application
            {
                CandidateProfileId = candidate.Id,
                JobId = dto.JobId,
                ResumeId = dto.ResumeId,
                CoverNote = dto.CoverNote,
                AppliedAt = DateTime.UtcNow,
                Status = ApplicationStatus.Pending
            };
            _context.Applications.Add(application);
            job.ApplicantCount++;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Application submitted successfully."
            });
        }
    }
}