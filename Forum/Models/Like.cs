using System.Text.Json.Serialization;
using Forum.Models;

public class Like
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }
    public bool IsLike { get; set; }

    [JsonIgnore]
    public Post Post { get; set; }
    [JsonIgnore]
    public User User { get; set; }
}