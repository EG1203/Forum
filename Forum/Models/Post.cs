using System;
using System.Collections.Generic;

namespace Forum.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public DateTime Date { get; set; }
        public int Uid { get; set; }

        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}