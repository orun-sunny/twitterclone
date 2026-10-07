using Microsoft.EntityFrameworkCore;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Data
{
    public class TwitterCloneDbContext : DbContext
    {
        public TwitterCloneDbContext(DbContextOptions<TwitterCloneDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Tweet> Tweets => Set<Tweet>();
        public DbSet<Like> Likes => Set<Like>();
        public DbSet<Follow> Follows => Set<Follow>();
        public DbSet<Bookmark> Bookmarks => Set<Bookmark>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<Retweet> Retweets => Set<Retweet>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Tweet>().ToTable("Tweets");
            modelBuilder.Entity<Like>().ToTable("Likes");
            modelBuilder.Entity<Follow>().ToTable("Follows");
            modelBuilder.Entity<Bookmark>().ToTable("Bookmarks");
            modelBuilder.Entity<Message>().ToTable("Messages");
            modelBuilder.Entity<Retweet>().ToTable("Retweets");

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var idProperty = entityType.FindProperty(nameof(BaseEntity.Id));
                if (idProperty is not null)
                {
                    idProperty.ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.Never;
                }
            }

            modelBuilder.Entity<Like>()
                .HasIndex(like => new { like.UserId, like.TweetId });
        }
    }
}
