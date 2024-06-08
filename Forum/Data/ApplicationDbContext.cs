using System;
using Forum.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Forum.Data
{
    public class
        ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Trend> Trends { get; set; }
        public DbSet<UserAction> UserActions { get; set; }
        public DbSet<UserKarma> UserKarmas { get; set; }
        public DbSet<User> Users { get; set; }
    }

}
