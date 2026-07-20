using System;
using System.Collections.Generic;
using System.Text;

namespace AIRecruitment.Domain.Entities
{
    public class CandidateProfile
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime DOB { get; set; }
        public int YearsofExperience { get; set; }
        public string Summary { get; set; }
        public string LinkedinUrl { get; set; }
        public string GithubUrl { get; set; }
        public string PortfolioUrl { get; set; }

        //navigational props
        //public ApplicationUser Candidate { get; set; }

        public List<Resume> Resumes { get; set; }

        //public List<CandidateSkill> CandidateSkills { get; set; }

        //public List<Application> Applications { get; set; }


    }
}
