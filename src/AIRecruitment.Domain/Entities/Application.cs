using AIRecruitment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIRecruitment.Domain.Entities
{
    public class Application
    {
        public DateTime AppliedAt { get; set; }
        public ApplicationStatus Status { get; set; }

        //fk
        public int CandidateProfileId { get; set; }
        public int JobId { get; set; }
        public int ResumeId { get; set; }

        //navigational props
        public CandidateProfile CandidateProfile { get; set; }

        public Job Job { get; set; }

        public Resume Resume { get; set; }
        public AIAnalysis AIAnalysis { get; set; }
        public List<Interview> Interviews { get; set; }

    }
}
