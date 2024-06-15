using System.Text.Json.Serialization;
using Forum.Models;

public class Subscription
{
    public int Id { get; set; }
    public int SubscriberId { get; set; }
    public int SubscribedToId { get; set; }

    [JsonIgnore]
    public User Subscriber { get; set; }
    [JsonIgnore]
    public User SubscribedTo { get; set; }
}