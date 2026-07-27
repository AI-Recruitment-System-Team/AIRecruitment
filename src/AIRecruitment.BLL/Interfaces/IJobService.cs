using AIRecruitment.BLL.DTOs.Job;
using AIRecruitment.BLL.DTOs.Dashboard;

namespace AIRecruitment.BLL.Interfaces
{
    public interface IJobService
    {
        //Returns all availavle jobs
        Task<List<GetJobDto>> GetAllJobsAsync(
            string? keyword,
            decimal? minSalary,
            string? skill);

        //Returns a specific job by its id
        Task<GetJobDto?> GetJobByIdAsync(int id);

        //Creates a new job posted by a recruiter
        Task CreateJobAsync(CreateJobDto dto, string recruiterId);

        //Update an existing job 
        Task UpdateJobAsync(int id, UpdateJobDto dto);

        //Delete an existing job 
        Task DeleteJobeAsync(int id);

        //Returns all jobs created by the recruiter
        Task<List<RecruiterJobDto>> GetRecruiterJobsAsync(string recruiterId);

        //Toggle job status between Open and Closed
        Task ToggleJobStatusAsync(int jobId);

        // Returns recruiter dashboard statistics and recent activity.
        Task<RecruiterDashboardDto> GetRecruiterDashboardAsync(string recruiterId);
    }
}