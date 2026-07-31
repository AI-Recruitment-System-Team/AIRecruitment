using AIRecruitment.DAL.Context;
using AIRecruitment.Domain.Entities;
using AIRecruitment.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace AIRecruitment.DAL.Seed;

public static class ApplicationSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.Applications.AnyAsync())
            return;

        var candidates = await context.CandidateProfiles.ToListAsync();
        var resumes = await context.Resumes.ToListAsync();
        var jobs = await context.Jobs.ToListAsync();

        var random = new Random();

        var applications = new List<Application>();

        foreach (var candidate in candidates)
        {
            var candidateResume = resumes.First(r => r.CandidateProfileId == candidate.Id);

            var selectedJobs = jobs
                .OrderBy(x => random.Next())
                .Take(2)
                .ToList();

            foreach (var job in selectedJobs)
            {
                applications.Add(new Application
                {
                    CandidateProfileId = candidate.Id,
                    ResumeId = candidateResume.Id,
                    JobId = job.Id,
                    AppliedAt = DateTime.UtcNow.AddDays(-random.Next(1, 15)),
                    Status = ApplicationStatus.Pending,
                    CoverNote = "I am excited to apply for this position."
                });

                job.ApplicantCount++;
            }
        }

        await context.Applications.AddRangeAsync(applications);
        await context.SaveChangesAsync();
    }
}