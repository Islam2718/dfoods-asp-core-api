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
    public class FoodCategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FoodCategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/food-categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodCategory>>> GetFoodCategories()
        {
            return await _context.FoodCategories.ToListAsync();
        }

        // GET: api/food-categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodCategory>> GetFoodCategory(int id)
        {
            var post = await _context.FoodCategories.FindAsync(id);
            if (post == null) return NotFound();
            return post;
        }

        // POST: api/food-categories
        [HttpPost]
        public async Task<ActionResult<FoodCategory>> PostFood(FoodCategory post)
        {
            _context.FoodCategories.Add(post);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFoodCategory), new { id = post.Id }, post);
        }

        // PUT: api/food-categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodCategory(int id, FoodCategory post)
        {
            // if (id != post.Id) return BadRequest();
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/food-categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodCategory(int id)
        {
            var post = await _context.FoodCategories.FindAsync(id);
            if (post == null) return NotFound();
            _context.FoodCategories.Remove(post);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}