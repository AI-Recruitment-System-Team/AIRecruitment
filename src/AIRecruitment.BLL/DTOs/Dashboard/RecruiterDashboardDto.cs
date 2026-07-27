namespace AIRecruitment.BLL.DTOs.Dashboard
{
    public class RecruiterDashboardDto
    {
        public int ActiveJobs { get; set; }
        public int TotalApplicants { get; set; }
        public int AIShortlisted { get; set; }
        public int ScheduledInterviews { get; set; }

        public List<RecentApplicationDto> RecentApplications { get; set; }
        public List<ScheduledInterviewDto> ScheduledInterviewsList { get; set; }
    }
}