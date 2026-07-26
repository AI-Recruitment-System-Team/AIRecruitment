public class GetJobDto
{
    public int Id { get; set; }
    public string Company { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal MinSalary { get; set; }
    public decimal MaxSalary { get; set; }
    public int ApplicantCount { get; set; }
    public string EmploymentType { get; set; }
    public int ExperienceRequired { get; set; }
    public string Location { get; set; }
    public DateTime PostedDate { get; set; }
    public DateTime Deadline { get; set; }
    public string Status { get; set; }
    public List<string> Skills { get; set; } = new();
}