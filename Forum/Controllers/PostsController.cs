using System;
namespace Forum.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Forum.Data;
using Forum.Models;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PostsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
    {
        return await _context.Posts.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> GetPost(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null)
        {
            return NotFound();
        }
        return post;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> PostPost(Post post)
    {
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetPost", new { id = post.Id }, post);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPost(int id, Post post)
    {
        if (id != post.Id)
        {
            return BadRequest();
        }
        _context.Entry(post).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Posts.Any(e => e.Id == id))
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
    public async Task<IActionResult> DeletePost(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null)
        {
            return NotFound();
        }
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

