using System;
namespace Forum.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Img { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<UserAction> UserActions { get; set; }
        public virtual ICollection<UserKarma> UserKarmas { get; set; }
    }

}




