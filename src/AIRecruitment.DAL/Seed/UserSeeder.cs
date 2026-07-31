using AIRecruitment.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AIRecruitment.DAL.Seed;

public static class UserSeeder
{
    public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
    {
        var users = new List<(string FirstName, string LastName, string Email, string Headline, string Role)>
{

// Recruiters
("Jana", "Ali", "recruiter1@gmail.com", "Senior Recruiter", "Recruiter"),
("Sara", "Mohamed", "recruiter2@gmail.com", "Technical Recruiter", "Recruiter"),

// Candidates
("Mohamed", "Hassan", "candidate1@gmail.com", ".NET Backend Developer", "Candidate"),
("Mariem", "Adel", "candidate2@gmail.com", "Frontend React Developer", "Candidate"),
("Omar", "Khaled", "candidate3@gmail.com", "Full Stack Developer", "Candidate"),
("Sophia", "Ahmed", "candidate4@gmail.com", "AI Engineer", "Candidate"),
("Youssef", "Mostafa", "candidate5@gmail.com", "DevOps Engineer", "Candidate")
};

        foreach (var userData in users)
        {
            if (await userManager.FindByEmailAsync(userData.Email) != null)
                continue;

            var user = new ApplicationUser
            {
                UserName = userData.Email,
                Email = userData.Email,
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                Headline = userData.Headline,
                AvatarUrl = "",
                IsActive = true,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, "Password@123");

            if (result.Succeeded)
                await userManager.AddToRoleAsync(user, userData.Role);
        }
    }
}