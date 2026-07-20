using AIRecruitment.Domain.Enums;
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
            //
        }
    }
}
