namespace AIRecruitment.Domain.Entities
{
    public class Job
    {
        public int Id { get; set; }

        public string RecruiterId { get; set; }

        public DateTime Deadline { get; set; }

        public string EmploymentType { get; set; }

        public string Title { get; set; }

        public DateTime CreatedAt { get; set; }

        public string SalaryRange { get; set; }

        public string Description { get; set; }

        public int ExperienceRequired { get; set; }

        public string Requirements { get; set; }

        // Navigational Properties

        public ApplicationUser Recruiter { get; set; }

        public List<JobSkill> JobSkills { get; set; }

        //public List<Application> Applications { get; set; }
    }
}