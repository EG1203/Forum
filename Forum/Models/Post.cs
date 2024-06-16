using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Forum.Models
{
    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string img { get; set; }
        public DateTime date { get; set; }
        public int uid { get; set; }

        [JsonIgnore]
        public User user { get; set; }
        [JsonIgnore]
        public ICollection<Comment> comments { get; set; }
        [JsonIgnore]
        public ICollection<Like> likes { get; set; }
    }
}