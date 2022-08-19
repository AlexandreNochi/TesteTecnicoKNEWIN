using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using TesteTecnicoKNEWIN.Data;
using TesteTecnicoKNEWIN.DTOs;
using TesteTecnicoKNEWIN.Models;

namespace TesteTecnicoKNEWIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PostsController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/Post by User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts([FromQuery] int? userId)
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }

            if (userId == null)
                return await _context.Posts.ToListAsync();

            return await _context.Posts.Where(x => x.UserId == userId).ToListAsync();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
          if (_context.Posts == null)
          {
              return NotFound();
          }
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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
                if (!PostExists(id))
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

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost([FromBody]PostDTO postData)
        {
            if (_context.Posts == null)
                return Problem("Entity set 'AppDbContext.Posts'  is null.");

            if (ModelState.ValidationState != ModelValidationState.Valid)
                return BadRequest();

            Post post = new(postData.UserId, postData.Title, postData.Content);
            
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Posts/6
        [HttpDelete]
        public async Task<IActionResult> DeletePosts([FromQuery] int? userId)
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }

            if (userId == null)
                return BadRequest(new {ErrorMensage = "UserId invalido"});

            var posts = await _context.Posts.Where(x => x.UserId == userId).ToListAsync();

            foreach (var post in posts)
                _context.Entry(post).State = EntityState.Deleted;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostExists(int id)
        {
            return (_context.Posts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
