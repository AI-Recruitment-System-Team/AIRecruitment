namespace AIRecruitment.BLL.DTOs.Application
{
    public class CreateApplicationDto
    {
        public required int JobId { get; set; }
        public required int ResumeId { get; set; }
        public string? CoverNote { get; set; }
    }
}