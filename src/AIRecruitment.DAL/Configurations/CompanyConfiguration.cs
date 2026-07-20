using AIRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIRecruitment.DAL.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasMaxLength(100);

            builder.Property(c => c.Description)
                .HasMaxLength(3000);

            builder.Property(c => c.WebsiteUrl)
                .HasMaxLength(500);

            builder.Property(c => c.LogoUrl)
                .HasMaxLength(500);
           
        }
    }
}
