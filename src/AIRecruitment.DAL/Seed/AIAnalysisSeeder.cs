using AIRecruitment.DAL.Context;
using AIRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AIRecruitment.DAL.Seed;

public static class AIAnalysisSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.AIAnalyses.AnyAsync())
            return;

        var random = new Random();

        var analyses = await context.Applications
        .Select(a => new AIAnalysis
        {
            ApplicationId = a.Id,
            MatchScore = random.Next(65, 100),
            AnalyzedAt = DateTime.UtcNow,
            Recommendations = "Candidate is suitable for the position.",
            MatchedSkills = "C#, ASP.NET Core, SQL Server",
            MissingSkills = "Docker",
            Summary = "Strong technical profile."
        }).ToListAsync();

        await context.AIAnalyses.AddRangeAsync(analyses);
        await context.SaveChangesAsync();
    }
}