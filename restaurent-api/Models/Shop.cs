namespace restaurent_api.models
{
    public class Shop
    {
        public Guid Id { get; set; }
        public int? UserId { get; set; }
        public required string ShopName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }  
    }
}