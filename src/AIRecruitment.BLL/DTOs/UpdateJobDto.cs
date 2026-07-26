namespace AIRecruitment.BLL.DTOs.Job;

public class UpdateJobDto
{
    public int CompanyId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal MinSalary { get; set; }
    public decimal MaxSalary { get; set; }
    public string EmploymentType { get; set; }
    public int ExperienceRequired { get; set; }
    public string Requirements { get; set; }
    public string Location { get; set; }
    public DateTime Deadline { get; set; }
}
