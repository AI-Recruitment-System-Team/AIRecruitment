using System;
using System.Collections.Generic;
using System.Text;

namespace AIRecruitment.Domain.Entities
{
    public class Resume
    {
        public int Id { get; set; }

        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string ExtractedText { get; set; }
        public DateTime UploadedAt { get; set; }

        //fk
        public int CandidateProfileId { get; set; }

        //navigational props
        public CandidateProfile CandidateProfile { get; set; }

        public List<Application> Applications { get; set; }


    }
}
