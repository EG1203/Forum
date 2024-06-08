using System;
namespace Forum.Models
{
    public class Trend
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Topic { get; set; }
        public int Mentions { get; set; }
        public DateTime TrendDate { get; set; }

        public virtual Post Post { get; set; }
    }

}

