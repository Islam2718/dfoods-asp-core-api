// using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using restaurent_api.Data;
using restaurent_api.models;

namespace restaurent_api.Controllers
{
    [Route("/api/[controller]")]
    // [Microsoft.AspNetCore.Components.Route("/api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ShopsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/shops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shop>>> GetShops()
        {
            return await _context.Shops.ToListAsync();
        }

        // GET: api/shops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shop>> GetShop(int id)
        {
            var post = await _context.Shops.FindAsync(id);
            if (post == null) return NotFound();
            return post;
        }

        // POST: api/shops
        [HttpPost]
        public async Task<ActionResult<Shop>> PostShop(Shop post)
        {
            _context.Shops.Add(post);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetShop), new { id = post.Id }, post);
        }

        // PUT: api/shops/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShop(int id, Shop post)
        {
            // if (id != post.Id) return BadRequest();
            // if (id !== post.Id) return BadRequest();
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/blogposts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShop(int id)
        {
            var post = await _context.Shops.FindAsync(id);
            if (post == null) return NotFound();
            _context.Shops.Remove(post);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}