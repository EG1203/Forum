using System;
namespace Forum.Models
{
    public class Media
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Type { get; set; }
        public string FilePath { get; set; }
        public DateTime Date { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }

}

