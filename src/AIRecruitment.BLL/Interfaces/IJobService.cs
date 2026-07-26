using AIRecruitment.BLL.DTOs.Job;

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
    }
}