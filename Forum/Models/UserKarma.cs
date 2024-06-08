using System;
namespace Forum.Models
{
    public class UserKarma
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Points { get; set; }

        public virtual User User { get; set; }
    }

}

