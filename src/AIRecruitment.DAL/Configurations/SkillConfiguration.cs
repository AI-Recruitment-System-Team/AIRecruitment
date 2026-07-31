using AIRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIRecruitment.DAL.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {

        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(s => s.Name).IsUnique();

            //relationships

            builder.HasMany(s => s.CandidateSkills)
                .WithOne(cs => cs.Skill)
                .HasForeignKey(cs => cs.SkillId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
