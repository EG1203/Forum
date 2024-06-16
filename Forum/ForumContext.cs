using Microsoft.EntityFrameworkCore;
using Forum.Models;

namespace Forum.Data
{
    public class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions<ForumContext> options) : base(options)
        {
        }

        public DbSet<Post> posts { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Like> likes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.posts)
                .WithOne(p => p.user)
                .HasForeignKey(p => p.uid);

            modelBuilder.Entity<User>()
                .HasMany(u => u.comments)
                .WithOne(c => c.user)
                .HasForeignKey(c => c.user_id);

            modelBuilder.Entity<User>()
                .HasMany(u => u.likes)
                .WithOne(l => l.user)
                .HasForeignKey(l => l.user_id);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.comments)
                .WithOne(c => c.post)
                .HasForeignKey(c => c.post_id);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.likes)
                .WithOne(l => l.post)
                .HasForeignKey(l => l.post_id);
        }
    }
}