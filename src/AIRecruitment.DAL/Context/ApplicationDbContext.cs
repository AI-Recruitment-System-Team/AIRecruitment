using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AIRecruitment.Domain.Entities;

namespace AIRecruitment.DAL.Context;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }


    public DbSet<ApplicationUser> ApplicationUser { get; set; }

    public DbSet<Company> Companies { get; set; }
    public DbSet<CandidateProfile> CandidateProfiles { get; set; }
    public DbSet<Resume> Resumes { get; set; }
    public DbSet<CandidateSkill> CandidateSkills { get; set; }
    public DbSet<Application> Application { get; set; }
    public DbSet<AIAnalysis> AIAnalyses { get; set; }


}