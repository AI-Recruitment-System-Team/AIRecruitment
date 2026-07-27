namespace AIRecruitment.BLL.DTOs.Dashboard
{
    public class ScheduledInterviewDto
    {
        public int InterviewId { get; set; }
        public string CandidateName { get; set; }
        public string JobTitle { get; set; }
        public DateTime InterviewDate { get; set; }
    }
}