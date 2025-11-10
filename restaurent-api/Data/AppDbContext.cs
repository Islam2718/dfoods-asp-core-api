using Microsoft.EntityFrameworkCore;
using restaurent_api.models;

namespace restaurent_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Shop> Shops => Set<Shop>();
        public DbSet<FoodCategory> FoodCategories => Set<FoodCategory>();
        public DbSet<Food> Foods => Set<Food>();
    }
}