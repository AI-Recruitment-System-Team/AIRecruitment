using AIRecruitment.DAL.Context;
using AIRecruitment.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AIRecruitment.DAL.Seed;

public static class JobSeeder
{
    public static async Task SeedAsync(
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager)
    {
        if (await context.Jobs.AnyAsync())
            return;

        var recruiters = await userManager.GetUsersInRoleAsync("Recruiter");
        var companies = await context.Companies.ToListAsync();

        Console.WriteLine($"Recruiters: {recruiters.Count}");
        Console.WriteLine($"Companies: {companies.Count}");

        var jobs = new List<Job>
        {
            new()
            {
                Title = "Backend .NET Developer",
                Description = "Build scalable RESTful APIs using ASP.NET Core.",
                Requirements = "C#, ASP.NET Core, Entity Framework Core, SQL Server, Git",
                EmploymentType = "Full-Time",
                MinSalary = 12000,
                MaxSalary = 18000,
                Location = "Alexandria",
                ExperienceRequired = 2
            },

            new()
            {
                Title = "Senior .NET Developer",
                Description = "Lead backend development and mentor junior developers.",
                Requirements = "C#, ASP.NET Core, SQL Server, Azure, Docker",
                EmploymentType = "Full-Time",
                MinSalary = 20000,
                MaxSalary = 28000,
                Location = "Cairo",
                ExperienceRequired = 5
            },

            new()
            {
                Title = "Frontend React Developer",
                Description = "Develop responsive React applications.",
                Requirements = "React, JavaScript, HTML, CSS, Redux",
                EmploymentType = "Full-Time",
                MinSalary = 10000,
                MaxSalary = 16000,
                Location = "Remote",
                ExperienceRequired = 2
            },

            new()
            {
                Title = "Angular Developer",
                Description = "Build modern Angular dashboards and web applications.",
                Requirements = "Angular, TypeScript, HTML, CSS",
                EmploymentType = "Full-Time",
                MinSalary = 12000,
                MaxSalary = 17000,
                Location = "Alexandria",
                ExperienceRequired = 2
            },

            new()
            {
                Title = "Full Stack Developer",
                Description = "Develop both backend and frontend applications.",
                Requirements = "C#, ASP.NET Core, React, SQL Server, Git",
                EmploymentType = "Full-Time",
                MinSalary = 18000,
                MaxSalary = 24000,
                Location = "Cairo",
                ExperienceRequired = 4
            },

            new()
            {
                Title = "AI Engineer",
                Description = "Develop and deploy AI and deep learning models.",
                Requirements = "Python, TensorFlow, Machine Learning, Deep Learning",
                EmploymentType = "Full-Time",
                MinSalary = 22000,
                MaxSalary = 30000,
                Location = "Remote",
                ExperienceRequired = 3
            },

            new()
            {
                Title = "Machine Learning Engineer",
                Description = "Train and optimize machine learning models.",
                Requirements = "Python, PyTorch, Scikit-learn, Pandas",
                EmploymentType = "Full-Time",
                MinSalary = 24000,
                MaxSalary = 32000,
                Location = "Remote",
                ExperienceRequired = 4
            },

            new()
            {
                Title = "DevOps Engineer",
                Description = "Manage CI/CD pipelines and cloud infrastructure.",
                Requirements = "Docker, Kubernetes, Azure DevOps, CI/CD",
                EmploymentType = "Full-Time",
                MinSalary = 20000,
                MaxSalary = 27000,
                Location = "Cairo",
                ExperienceRequired = 3
            },

            new()
            {
                Title = "Data Analyst",
                Description = "Analyze recruitment data and generate business insights.",
                Requirements = "SQL, Power BI, Excel, Python",
                EmploymentType = "Full-Time",
                MinSalary = 14000,
                MaxSalary = 19000,
                Location = "Alexandria",
                ExperienceRequired = 2
            },

            new()
            {
                Title = "QA Engineer",
                Description = "Perform manual and automated software testing.",
                Requirements = "Manual Testing, Selenium, Postman, JMeter",
                EmploymentType = "Full-Time",
                MinSalary = 12000,
                MaxSalary = 17000,
                Location = "Remote",
                ExperienceRequired = 2
            }
        };

        var now = DateTime.UtcNow;

        for (int i = 0; i < jobs.Count; i++)
        {
            jobs[i].RecruiterId = recruiters[i % recruiters.Count].Id;
            jobs[i].CompanyId = companies[i % companies.Count].Id;
            jobs[i].ApplicantCount = 0;
            jobs[i].CreatedAt = now;
            jobs[i].Deadline = now.AddDays(30 + i);
            jobs[i].Status = "Open";
        }

        await context.Jobs.AddRangeAsync(jobs);
        await context.SaveChangesAsync();
    }
}