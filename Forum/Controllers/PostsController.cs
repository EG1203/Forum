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
    public class PostsController : ControllerBase
    {
        private readonly ForumContext _context;

        public PostsController(ForumContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _context.posts.ToListAsync();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // POST: api/Posts
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost([FromBody] PostDTO postDto)
        {
            if (postDto == null)
            {
                return BadRequest("Post data is required.");
            }

            var post = new Post
            {
                title = postDto.title,
                description = postDto.description,
                img = postDto.img,
                date = postDto.date,
                uid = postDto.uid
            };

            _context.posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.id }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}