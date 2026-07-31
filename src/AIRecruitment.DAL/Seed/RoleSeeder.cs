using Microsoft.AspNetCore.Identity;

namespace AIRecruitment.DAL.Seed;

public static class RoleSeeder
{
    public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
    {
        string[] roles =
        {
            "Recruiter",
            "Candidate"
        };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}