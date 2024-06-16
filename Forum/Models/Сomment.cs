using System;
using System.Text.Json.Serialization;

namespace Forum.Models
{
    public class Comment
    {
        public int id { get; set; }
        public int post_id { get; set; }
        public int user_id { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }

        [JsonIgnore]
        public Post post { get; set; }
        [JsonIgnore]
        public User user { get; set; }
    }
}