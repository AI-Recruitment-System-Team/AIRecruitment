using System;
using System.Collections.Generic;
using System.Text;

namespace AIRecruitment.Domain.Entities
{
    public class AIAnalysis
    {
        public int Id { get; set; }
        public string MatchScore { get; set; }
        public DateTime AnalyzedAt { get; set; }
        public string Recommendations { get; set; }
        public string MatchedSkills { get; set; }
        public string MissingSkills { get; set; }
        public string Summary { get; set; }

        //fk
        public int ApplicationId { get; set; }

        //navigational props
        public Application Application { get; set; }

    }
}
