using System.Text.Json.Serialization;

namespace Forum.Models
{
    public class Like
    {
        public int id { get; set; }
        public int post_id { get; set; }
        public int user_id { get; set; }
        public bool is_like { get; set; }

        [JsonIgnore]
        public Post post { get; set; }
        [JsonIgnore]
        public User user { get; set; }
    }
}