namespace Forum.Models
{
    public class UserDTO
    {
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }

    public class LoginDTO
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}