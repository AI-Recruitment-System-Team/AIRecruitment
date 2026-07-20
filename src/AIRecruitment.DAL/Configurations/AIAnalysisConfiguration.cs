using AIRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIRecruitment.DAL.Configurations
{
    public class AIAnalysisConfiguration : IEntityTypeConfiguration<AIAnalysis>
    {
        public void Configure(EntityTypeBuilder<AIAnalysis> builder)
        {

            builder.Property(ai => ai.MatchScore)
                .HasMaxLength(100);

            builder.Property(ai => ai.AnalyzedAt);

            builder.Property(ai => ai.Recommendations)
                .HasMaxLength(1000);

            builder.Property(ai => ai.MatchedSkills);

            builder.Property(ai => ai.MissingSkills);

            builder.Property(ai => ai.Recommendations)
                .HasMaxLength(1000);

            builder.Property(ai => ai.AnalyzedAt);

            builder.HasOne(ai => ai.Application)
                .WithOne(a => a.AIAnalysis)
                .HasForeignKey<AIAnalysis>(ai => ai.ApplicationId)
                .OnDelete(DeleteBehavior.Restrict); ;


        }
    }
}
