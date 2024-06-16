using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Forum.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        [JsonIgnore]
        public ICollection<Post> posts { get; set; }
        [JsonIgnore]
        public ICollection<Comment> comments { get; set; }
        [JsonIgnore]
        public ICollection<Like> likes { get; set; }
    }
}