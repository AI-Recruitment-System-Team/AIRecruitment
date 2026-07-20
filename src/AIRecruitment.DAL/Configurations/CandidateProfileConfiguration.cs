using AIRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIRecruitment.DAL.Configurations
{
    public class CandidateProfileConfiguration : IEntityTypeConfiguration<CandidateProfile>
    {
        public void Configure(EntityTypeBuilder<CandidateProfile> builder)
        {
            builder.HasKey(cp => cp.Id);

            builder.Property(cp => cp.Country)
                .HasMaxLength(100);

            builder.Property(cp => cp.City)
                .HasMaxLength(100);

            builder.Property(cp => cp.DOB)
                .HasColumnType("date");

            builder.Property(cp => cp.YearsofExperience);

            builder.Property(cp => cp.Summary)
                .HasMaxLength(3000);

            builder.Property(cp => cp.LinkedinUrl)
                .HasMaxLength(500);

            builder.Property(cp => cp.GithubUrl)
                .HasMaxLength(500);

            builder.Property(cp => cp.PortfolioUrl)
                .HasMaxLength(500);

            //relationships
        }
    }
}
