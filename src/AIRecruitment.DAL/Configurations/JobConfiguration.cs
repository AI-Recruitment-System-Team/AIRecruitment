using AIRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIRecruitment.DAL.Configurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(j => j.Id);

            builder.Property(j => j.Title)
                   .HasMaxLength(200);

            builder.Property(j => j.Description)
                   .HasMaxLength(3000);

            builder.Property(j => j.Requirements)
                   .HasMaxLength(3000);

            builder.Property(j => j.EmploymentType)
                   .HasMaxLength(50);

            builder.Property(j => j.SalaryRange)
                   .HasMaxLength(100);

            builder.Property(j => j.CreatedAt);

            builder.Property(j => j.Deadline);

            builder.Property(j => j.ExperienceRequired);

            // Relationships

            builder.HasOne(j => j.Recruiter)
                   .WithMany(ap => ap.Jobs)
                   .HasForeignKey(j => j.RecruiterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(j => j.JobSkills)
                   .WithOne(js => js.Job)
                   .HasForeignKey(js => js.JobId)
                   .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasMany(j => j.Applications)
                   .WithOne(a => a.Job)
                   .HasForeignKey(a => a.JobId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}