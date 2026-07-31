using AIRecruitment.DAL.Context;
using AIRecruitment.Domain.Entities;
using AIRecruitment.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace AIRecruitment.DAL.Seed;

public static class CandidateSkillSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.CandidateSkills.AnyAsync())
            return;

        var random = new Random();

        var candidates = await context.CandidateProfiles.ToListAsync();
        var skills = await context.Skills.ToListAsync();

        var candidateSkills = new List<CandidateSkill>();

        foreach (var candidate in candidates)
        {
            var selectedSkills = skills
                .OrderBy(x => random.Next())
                .Take(5);

            foreach (var skill in selectedSkills)
            {
                candidateSkills.Add(new CandidateSkill
                {
                    CandidateProfileId = candidate.Id,
                    SkillId = skill.Id,
                    Level = (CandidateSkillLevel)random.Next(0, 4)
                });
            }
        }

        await context.CandidateSkills.AddRangeAsync(candidateSkills);
        await context.SaveChangesAsync();
    }
}