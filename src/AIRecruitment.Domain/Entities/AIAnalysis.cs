using System;
using System.Collections.Generic;
using System.Text;

namespace AIRecruitment.Domain.Entities
{
    public class AIAnalysis
    {
        public string MatchScore { get; set; }

        public DateTime AnalyzedAt { get; set; }
        public string Recommendations { get; set; }
        public List<string> MatchedSkills { get; set; }
        public List<string> MissingSkills { get; set; }
        public string Summary { get; set; }

        //fk
        public int ApplicationId { get; set; }

        //navigational props
        public Application Application { get; set; }

    }
}
