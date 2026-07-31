using AIRecruitment.DAL.Context;
using AIRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AIRecruitment.DAL.Seed;

public static class InterviewSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.Interviews.AnyAsync())
            return;

        var applications = await context.Applications
        .Take(6)
        .ToListAsync();

        var interviews = applications.Select(a => new Interview
        {
            ApplicationId = a.Id,
            InterviewDate = DateTime.UtcNow.AddDays(7),
            Notes = "Initial HR Interview",
            Status = "Scheduled",
            Location = "Microsoft Teams",
            MeetingLink = "https://teams.microsoft.com"
        });

        await context.Interviews.AddRangeAsync(interviews);
        await context.SaveChangesAsync();
    }
}