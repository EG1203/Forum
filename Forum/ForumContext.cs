using Microsoft.EntityFrameworkCore;

namespace Forum.Models
{
    public class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions<ForumContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("posts");
            modelBuilder.Entity<Comment>().ToTable("comments");
            modelBuilder.Entity<User>().ToTable("users");

            modelBuilder.Entity<Post>().HasKey(p => p.Id);
            modelBuilder.Entity<Post>().Property(p => p.Id).HasColumnName("id");
            modelBuilder.Entity<Post>().Property(p => p.Title).HasColumnName("title");
            modelBuilder.Entity<Post>().Property(p => p.Description).HasColumnName("description");
            modelBuilder.Entity<Post>().Property(p => p.Img).HasColumnName("img");
            modelBuilder.Entity<Post>().Property(p => p.Date).HasColumnName("date");
            modelBuilder.Entity<Post>().Property(p => p.Uid).HasColumnName("uid");

            modelBuilder.Entity<Comment>().HasKey(c => c.Id);
            modelBuilder.Entity<Comment>().Property(c => c.Id).HasColumnName("id");
            modelBuilder.Entity<Comment>().Property(c => c.PostId).HasColumnName("post_id");
            modelBuilder.Entity<Comment>().Property(c => c.UserId).HasColumnName("user_id");
            modelBuilder.Entity<Comment>().Property(c => c.Content).HasColumnName("content");
            modelBuilder.Entity<Comment>().Property(c => c.Date).HasColumnName("date");

            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("id");
            modelBuilder.Entity<User>().Property(u => u.Username).HasColumnName("username");
            modelBuilder.Entity<User>().Property(u => u.Email).HasColumnName("email");
            modelBuilder.Entity<User>().Property(u => u.Password).HasColumnName("password");
            modelBuilder.Entity<User>().Property(u => u.Img).HasColumnName("img");

            // Relationships
            modelBuilder.Entity<Comment>()
                .HasOne<Post>(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId);

            modelBuilder.Entity<Comment>()
                .HasOne<User>(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Post>()
                .HasOne<User>(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.Uid);
        }
    }
}