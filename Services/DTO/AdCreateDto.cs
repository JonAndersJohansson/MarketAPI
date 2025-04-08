using System.ComponentModel.DataAnnotations;

namespace Services.DTO
{
    public class AdCreateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(1000, MinimumLength = 3)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(0, 1_000_000)]
        public decimal Price { get; set; }

        [Required]
        public int CreatorId { get; set; }
    }

}
