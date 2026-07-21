using AIRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIRecruitment.DAL.Configurations
{
    public class ApplicationUserCongiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(ap => ap.FirstName)
                .HasMaxLength(50);

            builder.Property(ap => ap.LastName)
                .HasMaxLength(50);

            builder.Property(ap => ap.AvatarUrl)
                .HasMaxLength(500);

            builder.Property(ap => ap.IsActive);


            // Relationships

            builder.HasMany(ap => ap.Jobs)
                   .WithOne(j => j.Recruiter)
                   .HasForeignKey(j => j.RecruiterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(ap => ap.Notifications)
                   .WithOne(n => n.ApplicationUser)
                   .HasForeignKey(n => n.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ap => ap.CandidateProfile)
                   .WithOne(cp => cp.Candidate)
                   .HasForeignKey<CandidateProfile>(cp => cp.CandidateId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}