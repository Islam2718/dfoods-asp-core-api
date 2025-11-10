namespace restaurent_api.models
{
    public class FoodCategory
    {
        public Guid Id { get; set; }
        public required int UserId { get; set; }
        public required int ShopId { get; set; }
        public required string Categorytitle { get; set; }
        public string? CategoryDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }  
    }
}