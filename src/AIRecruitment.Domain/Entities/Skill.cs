using System;
using System.Collections.Generic;
using System.Text;

namespace AIRecruitment.Domain.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //navigational props
        public List<CandidateSkill> CandidateSkills { get; set; }
        //public List<JobSkill> JobSkills { get; set; }

    }
}
