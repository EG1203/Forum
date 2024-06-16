using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Models;
using Forum.Data;

namespace Forum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ForumContext _context;

        public SearchController(ForumContext context)
        {
            _context = context;
        }

        // GET: api/Search/Posts?query=searchText
        [HttpGet("Posts")]
        public async Task<ActionResult<IEnumerable<Post>>> SearchPosts(string query)
        {
            return await _context.posts
                .Where(p => p.title.Contains(query) || p.description.Contains(query))
                .ToListAsync();
        }

        // GET: api/Search/Comments?query=searchText
        [HttpGet("Comments")]
        public async Task<ActionResult<IEnumerable<Comment>>> SearchComments(string query)
        {
            return await _context.comments
                .Where(c => c.content.Contains(query))
                .ToListAsync();
        }
    }
}