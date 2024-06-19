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
    public class CommentsController : ControllerBase
    {
        private readonly ForumContext _context;

        public CommentsController(ForumContext context)
        {
            _context = context;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            return await _context.comments.ToListAsync();
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await _context.comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // POST: api/Comments
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment([FromBody] CommentDTO commentDto)
        {
            if (commentDto == null)
            {
                return BadRequest("Comment data is required.");
            }

            var comment = new Comment
            {
                post_id = commentDto.post_id,
                user_id = commentDto.user_id,
                content = commentDto.content,
                date = commentDto.date
            };

            _context.comments.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComment", new { id = comment.id }, comment);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _context.comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.comments.Remove(comment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}