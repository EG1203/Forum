using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using Forum.Models;
using Forum.Data;

namespace Forum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly ForumContext _context;

        public LikesController(ForumContext context)
        {
            _context = context;
        }

        // GET: api/Likes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Like>>> GetLikes()
        {
            return await _context.likes.ToListAsync();
        }

        // GET: api/Likes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Like>> GetLike(int id)
        {
            var like = await _context.likes.FindAsync(id);

            if (like == null)
            {
                return NotFound();
            }

            return like;
        }

        // POST: api/Likes
        [HttpPost]
        public async Task<ActionResult<Like>> PostLike([FromBody] LikeDTO likeDto)
        {
            if (likeDto == null)
            {
                return BadRequest("Like data is required.");
            }

            var like = new Like
            {
                post_id = likeDto.post_id,
                user_id = likeDto.user_id,
                is_like = likeDto.is_like
            };

            _context.likes.Add(like);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLike", new { id = like.id }, like);
        }

        // DELETE: api/Likes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLike(int id)
        {
            var like = await _context.likes.FindAsync(id);
            if (like == null)
            {
                return NotFound();
            }

            _context.likes.Remove(like);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}