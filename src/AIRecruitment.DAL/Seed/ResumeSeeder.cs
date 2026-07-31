using AIRecruitment.DAL.Context;
using AIRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AIRecruitment.DAL.Seed;

public static class ResumeSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.Resumes.AnyAsync())
            return;

        var candidateProfiles = await context.CandidateProfiles.ToListAsync();

        var resumes = new List<Resume>();

        foreach (var profile in candidateProfiles)
        {
            resumes.Add(new Resume
            {
                CandidateProfileId = profile.Id,
                FileName = $"Resume_{profile.Id}.pdf",
                FileUrl = $"https://example.com/resumes/resume_{profile.Id}.pdf",
                ExtractedText = "Experienced software engineer with strong knowledge of ASP.NET Core, Entity Framework Core, SQL Server, REST APIs, Git, Docker, and problem solving.",
                UploadedAt = DateTime.UtcNow
            });
        }

        await context.Resumes.AddRangeAsync(resumes);
        await context.SaveChangesAsync();
    }
}