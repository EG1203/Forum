using System;
namespace Forum.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public int SubscriberId { get; set; }
        public int SubscribedToId { get; set; }

        public virtual User Subscriber { get; set; }
        public virtual User SubscribedTo { get; set; }
    }

}

