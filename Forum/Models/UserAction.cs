using System;
namespace Forum.Models
{
    public class UserAction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ActionType { get; set; }
        public DateTime Date { get; set; }
        public int PointsChange { get; set; }

        public virtual User User { get; set; }
    }

}

