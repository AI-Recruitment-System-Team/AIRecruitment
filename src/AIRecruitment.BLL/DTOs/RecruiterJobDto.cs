public class RecruiterJobDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Company { get; set; }
    public string Location { get; set; }
    public string Status { get; set; }
    public string JobType { get; set; }
    public int ApplicantCount { get; set; }
    public DateTime CreatedAt { get; set; }
}