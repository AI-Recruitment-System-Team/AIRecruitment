using AIRecruitment.Domain.Enums;
namespace AIRecruitment.Domain.Entities
{
    public class CandidateSkill
    {
        public CandidateSkillLevel Level { get; set; }

        //fk
        public int CandidateProfileId { get; set; }
        public int SkillId { get; set; }

        //navigational properties
        public CandidateProfile CandidateProfile { get; set; }
        public Skill Skill { get; set; }

    }
}
