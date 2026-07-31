using AIRecruitment.DAL.Context;
using AIRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AIRecruitment.DAL.Seed;

public static class JobSkillSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.JobSkills.AnyAsync())
            return;

        var jobs = await context.Jobs
        .OrderBy(j => j.Id)
        .ToListAsync();

        var skills = await context.Skills.ToListAsync();

        int Skill(string name) => skills.First(s => s.Name == name).Id;

        var jobSkills = new List<JobSkill>
{

new() { JobId = jobs[0].Id, SkillId = Skill("C#"), IsRequired = true },
new() { JobId = jobs[0].Id, SkillId = Skill("ASP.NET Core"), IsRequired = true },
new() { JobId = jobs[0].Id, SkillId = Skill("Entity Framework Core"), IsRequired = true },
new() { JobId = jobs[0].Id, SkillId = Skill("SQL Server"), IsRequired = true },
new() { JobId = jobs[0].Id, SkillId = Skill("Git"), IsRequired = false },
new() { JobId = jobs[1].Id, SkillId = Skill("C#"), IsRequired = true },
new() { JobId = jobs[1].Id, SkillId = Skill("ASP.NET Core"), IsRequired = true },
new() { JobId = jobs[1].Id, SkillId = Skill("SQL Server"), IsRequired = true },
new() { JobId = jobs[1].Id, SkillId = Skill("Docker"), IsRequired = false },
new() { JobId = jobs[1].Id, SkillId = Skill("Azure"), IsRequired = false },
new() { JobId = jobs[2].Id, SkillId = Skill("React"), IsRequired = true },
new() { JobId = jobs[2].Id, SkillId = Skill("JavaScript"), IsRequired = true },
new() { JobId = jobs[2].Id, SkillId = Skill("HTML"), IsRequired = true },
new() { JobId = jobs[2].Id, SkillId = Skill("CSS"), IsRequired = true },
new() { JobId = jobs[2].Id, SkillId = Skill("Git"), IsRequired = false },
new() { JobId = jobs[3].Id, SkillId = Skill("Angular"), IsRequired = true },
new() { JobId = jobs[3].Id, SkillId = Skill("TypeScript"), IsRequired = true },
new() { JobId = jobs[3].Id, SkillId = Skill("HTML"), IsRequired = true },
new() { JobId = jobs[3].Id, SkillId = Skill("CSS"), IsRequired = true },
new() { JobId = jobs[4].Id, SkillId = Skill("C#"), IsRequired = true },
new() { JobId = jobs[4].Id, SkillId = Skill("ASP.NET Core"), IsRequired = true },
new() { JobId = jobs[4].Id, SkillId = Skill("React"), IsRequired = true },
new() { JobId = jobs[4].Id, SkillId = Skill("SQL Server"), IsRequired = true },
new() { JobId = jobs[5].Id, SkillId = Skill("Python"), IsRequired = true },
new() { JobId = jobs[5].Id, SkillId = Skill("Machine Learning"), IsRequired = true },
new() { JobId = jobs[5].Id, SkillId = Skill("Problem Solving"), IsRequired = true },
new() { JobId = jobs[5].Id, SkillId = Skill("Communication"), IsRequired = false },
new() { JobId = jobs[6].Id, SkillId = Skill("Python"), IsRequired = true },
new() { JobId = jobs[6].Id, SkillId = Skill("Machine Learning"), IsRequired = true },
new() { JobId = jobs[6].Id, SkillId = Skill("TensorFlow"), IsRequired = true },
new() { JobId = jobs[7].Id, SkillId = Skill("Docker"), IsRequired = true },
new() { JobId = jobs[7].Id, SkillId = Skill("Azure"), IsRequired = true },
new() { JobId = jobs[7].Id, SkillId = Skill("Git"), IsRequired = true },
new() { JobId = jobs[8].Id, SkillId = Skill("SQL Server"), IsRequired = true },
new() { JobId = jobs[8].Id, SkillId = Skill("Power BI"), IsRequired = true },
new() { JobId = jobs[8].Id, SkillId = Skill("Communication"), IsRequired = false },
new() { JobId = jobs[9].Id, SkillId = Skill("Manual Testing"), IsRequired = true },
new() { JobId = jobs[9].Id, SkillId = Skill("Automation Testing"), IsRequired = true },
new() { JobId = jobs[9].Id, SkillId = Skill("Problem Solving"), IsRequired = false }
};

        await context.JobSkills.AddRangeAsync(jobSkills);
        await context.SaveChangesAsync();
    }
}