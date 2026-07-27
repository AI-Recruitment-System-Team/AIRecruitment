using AIRecruitment.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AIRecruitment.BLL.DTOs.Job;
using Microsoft.AspNetCore.Authorization;

namespace AIRecruitment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        //Returns all available jobs
        [HttpGet]
        public async Task<IActionResult> GetAllJobs(
                [FromQuery] string? keyword,
                [FromQuery] decimal? minSalary,
                [FromQuery] string? skill)
        {
            var jobs = await _jobService.GetAllJobsAsync(keyword, minSalary, skill);
            return Ok(jobs);
        }

        //Returns a job by its ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobById(int id)
        {
            var job = await _jobService.GetJobByIdAsync(id);

            if (job == null)
                return NotFound("Job not found. ");

            return Ok(job);
        }

        //Returns all jobs created by the logged-in recruiter
        [Authorize(Roles = "Recruiter")]
        [HttpGet("my-jobs")]
        public async Task<IActionResult> GetRecruiterJobs()
        {
            var recruiterId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(recruiterId))
                return Unauthorized();

            var jobs = await _jobService.GetRecruiterJobsAsync(recruiterId);

            return Ok(jobs);
        }

        //Toggle job status
        [Authorize(Roles = "Recruiter")]
        [HttpPut("{id}/status")]
        public async Task<IActionResult> ToggleJobStatus(int id)
        {
            await _jobService.ToggleJobStatusAsync(id);

            return Ok(new
            {
                message = "Job status updated successfully."
            });
        }

        //Create a new job
        [Authorize(Roles = "Recruiter")]
        [HttpPost]
        public async Task<IActionResult> CreateJob(CreateJobDto dto)
        {
            var recruiterId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(recruiterId))
                return Unauthorized();

            await _jobService.CreateJobAsync(dto, recruiterId);

            return Ok(new
            {
                message = "Job created successfully."
            });
        }

        //Update an existing job
        [Authorize(Roles = "Recruiter")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, UpdateJobDto dto)
        {
            await _jobService.UpdateJobAsync(id, dto);

            return Ok(new
            {
                message = "Job updated successfully."
            });
        }

        //Delete a job
        [Authorize(Roles = "Recruiter")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            await _jobService.DeleteJobeAsync(id);

            return Ok(new
            {
                message = "Job deleted successfully."
            });
        }

        //Returns recruiter dashboard statistics
        [Authorize(Roles = "Recruiter")]
        [HttpGet("dashboard")]
        public async Task<IActionResult> GetRecruiterDashboard()
        {
            var recruiterId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(recruiterId))
                return Unauthorized();

            var dashboard = await _jobService.GetRecruiterDashboardAsync(recruiterId);

            return Ok(dashboard);
        }
    }
}