namespace AIRecruitment.Domain.Entities
{
    public class Interview
    {
        public int Id { get; set; }

        public int ApplicationId { get; set; }

        public DateTime InterviewDate { get; set; }

        public string Notes { get; set; }

        public string Status { get; set; }

        public string Location { get; set; }

        public string MeetingLink { get; set; }

        // Navigational Properties

        public Application Application { get; set; }

        public InterviewFeedback InterviewFeedback { get; set; }
    }
}
