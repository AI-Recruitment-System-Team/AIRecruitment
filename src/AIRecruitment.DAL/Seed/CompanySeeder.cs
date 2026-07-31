using AIRecruitment.DAL.Context;
using AIRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AIRecruitment.DAL.Seed;

public static class CompanySeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.Companies.AnyAsync())
            return;

        var companies = new List<Company>
{
new Company
{
Name = "Microsoft",
Description = "Global technology company specializing in software, cloud services, and AI.",
WebsiteUrl = "https://www.microsoft.com",
LogoUrl = "https://logo.clearbit.com/microsoft.com"
},
new Company
{
Name = "Google",
Description = "Technology company focused on search, cloud computing, and AI.",
WebsiteUrl = "https://www.google.com",
LogoUrl = "https://logo.clearbit.com/google.com"
},
new Company
{
Name = "Amazon",
Description = "E-commerce and cloud computing company.",
WebsiteUrl = "https://www.amazon.com",
LogoUrl = "https://logo.clearbit.com/amazon.com"
},
new Company
{
Name = "IBM",
Description = "Enterprise technology and consulting company.",
WebsiteUrl = "https://www.ibm.com",
LogoUrl = "https://logo.clearbit.com/ibm.com"
},
new Company
{
Name = "Oracle",
Description = "Enterprise software and cloud solutions provider.",
WebsiteUrl = "https://www.oracle.com",
LogoUrl = "https://logo.clearbit.com/oracle.com"
}
};

        await context.Companies.AddRangeAsync(companies);
        await context.SaveChangesAsync();
    }
}