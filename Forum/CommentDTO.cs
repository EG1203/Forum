using System;

namespace Forum.Models
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}