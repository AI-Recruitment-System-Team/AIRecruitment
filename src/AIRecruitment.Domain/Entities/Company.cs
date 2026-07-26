namespace AIRecruitment.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? LogoUrl { get; set; }

        // Navigation Property
        public List<Job> Jobs { get; set; }
    }
}
