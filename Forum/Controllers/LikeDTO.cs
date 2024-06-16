namespace Forum.Models
{
    public class LikeDTO
    {
        public int id { get; set; }
        public int post_id { get; set; }
        public int user_id { get; set; }
        public bool is_like { get; set; }
    }
}