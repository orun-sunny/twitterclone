using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(n => n.UserId).IsRequired();
            builder.Property(n => n.Type).IsRequired();
            builder.Property(n => n.IsRead).IsRequired();
            builder.Property<string>("Message");

            builder.HasDiscriminator(n => n.Type)
                .HasValue<LikeNotification>("Like")
                .HasValue<CommentNotification>("Comment")
                .HasValue<MentionNotification>("Mention")
                .HasValue<FriendRequestNotification>("FriendRequest")
                .HasValue<SystemNotification>("System");
        }
    }
}
