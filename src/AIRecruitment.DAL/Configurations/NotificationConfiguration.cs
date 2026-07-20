using AIRecruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIRecruitment.DAL.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Title)
                   .HasMaxLength(200);

            builder.Property(n => n.Message)
                   .HasMaxLength(3000);

            builder.Property(n => n.CreatedAt);

            builder.Property(n => n.IsRead);
            // Relationships

            builder.HasOne(n => n.ApplicationUser)
                   .WithMany(ap => ap.Notifications)
                   .HasForeignKey(n => n.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}