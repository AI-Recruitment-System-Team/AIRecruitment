using AIRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIRecruitment.DAL.Configurations
{
    public class InterviewConfiguration : IEntityTypeConfiguration<Interview>
    {
        public void Configure(EntityTypeBuilder<Interview> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.InterviewDate);

            builder.Property(i => i.Notes)
                   .HasMaxLength(2000);

            builder.Property(i => i.Status)
                   .HasMaxLength(50);

            builder.Property(i => i.Location)
                   .HasMaxLength(200);

            builder.Property(i => i.MeetingLink)
                   .HasMaxLength(500);

            // Relationships

            builder.HasOne(i => i.InterviewFeedback)
                   .WithOne(f => f.Interview)
                   .HasForeignKey<InterviewFeedback>(f => f.InterviewId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}