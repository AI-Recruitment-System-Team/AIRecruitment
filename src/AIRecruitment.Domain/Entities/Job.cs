namespace AIRecruitment.Domain.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string RecruiterId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string EmploymentType { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public string Location { get; set; }
        public int ExperienceRequired { get; set; }
        public int ApplicantCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Deadline { get; set; }
        public string Status { get; set; } = "Open";

        // Navigation Properties

        public ApplicationUser Recruiter { get; set; }
        public Company Company { get; set; }
        public List<JobSkill> JobSkills { get; set; }
        public List<Application> Applications { get; set; }
    }
}