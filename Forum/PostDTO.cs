namespace Forum.Models
{
    public class PostDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string img { get; set; }
        public DateTime date { get; set; }
        public int uid { get; set; }
    }
}