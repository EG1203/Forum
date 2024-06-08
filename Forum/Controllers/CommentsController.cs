using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Forum.Data;
using Forum.Models;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CommentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
    {
        return await _context.Comments.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Comment>> GetComment(int id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment == null)
        {
            return NotFound();
        }
        return comment;
    }

    [HttpPost]
    public async Task<ActionResult<Comment>> PostComment(Comment comment)
    {
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetComment", new { id = comment.Id }, comment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutComment(int id, Comment comment)
    {
        if (id != comment.Id)
        {
            return BadRequest();
        }

        _context.Entry(comment).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Comments.Any(e => e.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(int id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment == null)
        {
            return NotFound();
        }

        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

