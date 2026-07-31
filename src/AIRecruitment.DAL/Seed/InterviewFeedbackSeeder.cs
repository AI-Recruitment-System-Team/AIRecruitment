using AIRecruitment.DAL.Context;
using AIRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AIRecruitment.DAL.Seed;

public static class InterviewFeedbackSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.InterviewFeedbacks.AnyAsync())
            return;

        var random = new Random();

        var feedbacks = await context.Interviews
            .Select(i => new InterviewFeedback
            {
                InterviewId = i.Id,
                CommunicationScore = random.Next(7, 10),
                TechnicalScore = random.Next(7, 10),
                ProblemSolvingScore = random.Next(7, 10),
                Comments = "Excellent communication and technical skills.",
                Recommendation = "Proceed to the next stage."
            }).ToListAsync();

        await context.InterviewFeedbacks.AddRangeAsync(feedbacks);
        await context.SaveChangesAsync();
    }
}