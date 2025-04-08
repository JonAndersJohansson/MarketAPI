using System.ComponentModel.DataAnnotations;

namespace Services.DTO
{
    public class AdCreateDto
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Titel must be between 3 - 100 letters")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Description must be between 3 - 1000 letters")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Price is required.")]
        [Range(0, 1_000_000, ErrorMessage = "Price must be between 0 and 1000000.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "CreatorId is required")]
        public int CreatorId { get; set; }
    }
}
