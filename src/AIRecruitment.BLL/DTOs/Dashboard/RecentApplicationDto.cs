namespace AIRecruitment.BLL.DTOs.Dashboard
{
    public class RecentApplicationDto
    {
        public int ApplicationId { get; set; }
        public string CandidateName { get; set; }
        public string JobTitle { get; set; }
        public int MatchScore { get; set; }
        public DateTime AppliedAt { get; set; }
    }
}