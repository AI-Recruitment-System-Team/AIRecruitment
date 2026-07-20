using AIRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIRecruitment.DAL.Configurations
{
    public class InterviewFeedbackConfiguration : IEntityTypeConfiguration<InterviewFeedback>
    {
        public void Configure(EntityTypeBuilder<InterviewFeedback> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.CommunicationScore);

            builder.Property(i => i.TechnicalScore);

            builder.Property(i => i.ProblemSolvingScore);

            builder.Property(i => i.Comments)
                   .HasMaxLength(3000);

            builder.Property(i => i.Recommendation)
                   .HasMaxLength(1000);

            // Relationships

            builder.HasOne(f => f.Interview)
                   .WithOne(i => i.InterviewFeedback)
                   .HasForeignKey<InterviewFeedback>(f => f.InterviewId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
