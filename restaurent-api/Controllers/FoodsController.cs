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
    public class FoodsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FoodsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/foods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Food>>> GetFoods()
        {
            return await _context.Foods.ToListAsync();
        }

        // GET: api/foods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetFood(int id)
        {
            var post = await _context.Foods.FindAsync(id);
            if (post == null) return NotFound();
            return post;
        }

        // POST: api/shops
        [HttpPost]
        public async Task<ActionResult<Food>> PostFood(Food post)
        {
            _context.Foods.Add(post);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFood), new { id = post.Id }, post);
        }

        // PUT: api/shops/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFood(int id, Shop post)
        {
            // if (id != post.Id) return BadRequest();
            // if (id !== post.Id) return BadRequest();
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/blogposts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            var post = await _context.Shops.FindAsync(id);
            if (post == null) return NotFound();
            _context.Shops.Remove(post);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}