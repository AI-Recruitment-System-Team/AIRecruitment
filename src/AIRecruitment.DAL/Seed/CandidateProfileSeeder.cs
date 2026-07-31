using AIRecruitment.DAL.Context;
using AIRecruitment.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AIRecruitment.DAL.Seed;

public static class CandidateProfileSeeder
{
    public static async Task SeedAsync(
    ApplicationDbContext context,
    UserManager<ApplicationUser> userManager)
    {
        var candidateEmails = new[]
        {
"candidate1@gmail.com",
"candidate2@gmail.com",
"candidate3@gmail.com",
"candidate4@gmail.com",
"candidate5@gmail.com"
};

        foreach (var email in candidateEmails)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
                continue;

            if (await context.CandidateProfiles.AnyAsync(c => c.CandidateId == user.Id))
                continue;

            context.CandidateProfiles.Add(new CandidateProfile
            {
                CandidateId = user.Id,
                Country = "Egypt",
                City = "Alexandria",
                DOB = new DateTime(2003, 1, 1),
                YearsofExperience = Random.Shared.Next(1, 6),
                Summary = $"{user.Headline} passionate about software development.",
                LinkedinUrl = $"https://linkedin.com/in/{user.FirstName.ToLower()}",
                GithubUrl = $"https://github.com/{user.FirstName.ToLower()}",
                PortfolioUrl = $"https://{user.FirstName.ToLower()}.dev"
            });
        }

        await context.SaveChangesAsync();
    }
}