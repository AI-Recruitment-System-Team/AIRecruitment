using AIRecruitment.DAL.Context;
using AIRecruitment.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AIRecruitment.DAL.Seed;

public static class DbSeeder
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var context = services.GetRequiredService<ApplicationDbContext>();

        await RoleSeeder.SeedAsync(roleManager);
        await UserSeeder.SeedAsync(userManager);
        await CandidateProfileSeeder.SeedAsync(context, userManager);
        await CompanySeeder.SeedAsync(context);
        await SkillSeeder.SeedAsync(context);
        await JobSeeder.SeedAsync(context, userManager);
        await JobSkillSeeder.SeedAsync(context);
        await ResumeSeeder.SeedAsync(context);
        await CandidateSkillSeeder.SeedAsync(context);
        await ApplicationSeeder.SeedAsync(context);
        await AIAnalysisSeeder.SeedAsync(context);
        await InterviewSeeder.SeedAsync(context);
        await InterviewFeedbackSeeder.SeedAsync(context);
        await NotificationSeeder.SeedAsync(context);

    }
}