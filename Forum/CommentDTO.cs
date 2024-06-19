namespace Forum.Models
{
    public class CommentDTO
    {
        public int id { get; set; }
        public int post_id { get; set; }
        public int user_id { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }
    }
}