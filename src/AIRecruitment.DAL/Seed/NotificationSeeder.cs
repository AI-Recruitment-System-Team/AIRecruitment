using AIRecruitment.DAL.Context;
using AIRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AIRecruitment.DAL.Seed;

public static class NotificationSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.Notifications.AnyAsync())
            return;

        var users = await context.Users.ToListAsync();

        var notifications = new List<Notification>();

        foreach (var user in users)
        {
            notifications.Add(new Notification
            {
                UserId = user.Id,
                Title = "Welcome",
                Message = "Welcome to AI Recruitment System.",
                CreatedAt = DateTime.UtcNow,
                IsRead = false
            });

            notifications.Add(new Notification
            {
                UserId = user.Id,
                Title = "Application Update",
                Message = "Your application status has been updated.",
                CreatedAt = DateTime.UtcNow,
                IsRead = false
            });
        }

        await context.Notifications.AddRangeAsync(notifications);
        await context.SaveChangesAsync();
    }
}