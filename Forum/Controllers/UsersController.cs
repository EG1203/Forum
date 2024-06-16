using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Forum.Models;
using Forum.Data;

namespace Forum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ForumContext _context;

        public UsersController(ForumContext context)
        {
            _context = context;
        }

        // POST: api/Users/Register
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDTO userDto)
        {
            if (_context.users.Any(u => u.email == userDto.Email))
            {
                return BadRequest("Email is already registered.");
            }

            var user = new User
            {
                email = userDto.Email,
                username = userDto.Username,
                password = ComputeSha256Hash(userDto.Password)
            };

            _context.users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.id }, user);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users/Login
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(LoginDTO loginDto)
        {
            var user = await _context.users.SingleOrDefaultAsync(u => u.email == loginDto.Email);

            if (user == null || user.password != ComputeSha256Hash(loginDto.Password))
            {
                return Unauthorized("Invalid email or password.");
            }

            // Here you would generate a JWT token and return it
            return Ok(user);
        }

        private static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }

    public class UserDTO
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}