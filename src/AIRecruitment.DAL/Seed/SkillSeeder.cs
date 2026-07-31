using AIRecruitment.DAL.Context;
using AIRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AIRecruitment.DAL.Seed;

public static class SkillSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.Skills.AnyAsync())
            return;

        var skills = new List<Skill>
{
new() { Name = "C#" },
new() { Name = "ASP.NET Core" },
new() { Name = "Entity Framework Core" },
new() { Name = "SQL Server" },
new() { Name = "LINQ" },
new() { Name = "REST API" },
new() { Name = "JWT Authentication" },
new() { Name = "Git" },
new() { Name = "GitHub" },
new() { Name = "Docker" },
new() { Name = "Azure" },
new() { Name = "React" },
new() { Name = "Angular" },
new() { Name = "TypeScript" },
new() { Name = "JavaScript" },
new() { Name = "HTML" },
new() { Name = "CSS" },
new() { Name = "Python" },
new() { Name = "Machine Learning" },
new() { Name = "TensorFlow" },
new() { Name = "Power BI" },
new() { Name = "Manual Testing" },
new() { Name = "Automation Testing" },
new() { Name = "Problem Solving" },
new() { Name = "Communication" },
new() { Name = "Teamwork" }
};

        await context.Skills.AddRangeAsync(skills);
        await context.SaveChangesAsync();
    }
}