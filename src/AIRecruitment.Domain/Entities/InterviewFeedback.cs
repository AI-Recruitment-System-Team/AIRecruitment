namespace AIRecruitment.Domain.Entities
{

    public class InterviewFeedback
    {
        public int Id { get; set; }

        public int InterviewId { get; set; }

        public int CommunicationScore { get; set; }

        public int TechnicalScore { get; set; }

        public int ProblemSolvingScore { get; set; }

        public string Comments { get; set; }

        public string Recommendation { get; set; }

        // Navigational Properties

        public Interview Interview { get; set; }
    }
}
