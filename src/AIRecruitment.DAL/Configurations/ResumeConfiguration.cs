using AIRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIRecruitment.DAL.Configurations
{
    public class ResumeConfiguration : IEntityTypeConfiguration<Resume>
    {
        public void Configure(EntityTypeBuilder<Resume> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.FileName)
                .HasMaxLength(100);

            builder.Property(r => r.FileUrl)
                .HasMaxLength(500);

            builder.Property(r => r.ExtractedText)
                .HasMaxLength(1000);

            builder.Property(r => r.UploadedAt)
                .HasColumnType("date");

            builder.HasOne(r => r.CandidateProfile)
                .WithMany(cp => cp.Resumes)
                .HasForeignKey(r => r.CandidateProfileId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
