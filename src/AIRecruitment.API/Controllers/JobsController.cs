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
            
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobById(int id)
        {
            var job = await _jobService.GetJobByIdAsync(id);

            if(job == null)
                return NotFound("Job not found. ");

            return Ok(job);
        }

        //Create a new job
        [Authorize(Roles = "Recruiter")]
        [HttpPost]
        public async Task<IActionResult> CreateJob(CreateJobDto dto)
        {
            var recruiterId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if(string.IsNullOrEmpty(recruiterId))
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
    }
}