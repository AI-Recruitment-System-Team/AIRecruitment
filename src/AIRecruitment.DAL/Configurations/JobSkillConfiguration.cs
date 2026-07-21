using AIRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIRecruitment.DAL.Configurations
{
    public class JobSkillConfiguration : IEntityTypeConfiguration<JobSkill>
    {
        public void Configure(EntityTypeBuilder<JobSkill> builder)
        {
            builder.HasKey(js => js.Id);

            builder.Property(js => js.IsRequired);

            // Relationships

            builder.HasOne(js => js.Job)
                   .WithMany(j => j.JobSkills)
                   .HasForeignKey(js => js.JobId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(js => js.Skill)
                    .WithMany(s => s.JobSkills)
                    .HasForeignKey(js => js.SkillId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
