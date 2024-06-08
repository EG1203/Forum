using System;
namespace Forum.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }

        public virtual Category Category { get; set; }
    }

}

