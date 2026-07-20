using AIRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIRecruitment.DAL.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.Property(a => a.AppliedAt)
                .HasColumnType("date");

            builder.Property(a => a.Status)
               .HasConversion<string>();

            builder.HasOne(a => a.CandidateProfile)
                 .WithMany(cp => cp.Applications)
                 .HasForeignKey(a => a.CandidateProfileId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Resume)
                 .WithMany(r => r.Applications)
                 .HasForeignKey(a => a.ResumeId)
                 .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
