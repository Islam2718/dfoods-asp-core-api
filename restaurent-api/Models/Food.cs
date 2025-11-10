using Microsoft.AspNetCore.Components.Web;

namespace restaurent_api.models
{
    public class Food
    {
        public Guid Id { get; set; }
        public int? UserId { get; set; }
        public int? ShopId { get; set; }
        public int? FoodCategoryId { get; set; }
        public required string FoodTitle { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }        
    }
}