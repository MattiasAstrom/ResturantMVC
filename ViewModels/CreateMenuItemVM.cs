using System.ComponentModel.DataAnnotations;

namespace ResturantMVC.ViewModels
{
    public class CreateMenuItemVM
    {
        [Display(Name = "Dish Name")]
        [Required, StringLength(200)]
        public string Name { get; set; } = null!;

        [Display(Name = "Description")]
        [Required, StringLength(200)]
        public string? Description { get; set; }

        [Display(Name = "Image URL")]
        [Required]
        public string? ImageUrl { get; set; }

        [Display(Name = "Price")]
        [Required, Range(0.01, 9999.99, ErrorMessage = "Price must be between 0.01 and 9999.99.")]
        public decimal Price { get; set; }

        public bool IsPopular { get; set; }
    }
}
