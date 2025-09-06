namespace ResturantMVC.Models
{
    public class MenuItem
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsPopular { get; set; }
    }
}