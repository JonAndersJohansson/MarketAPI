using System.ComponentModel.DataAnnotations;

namespace Services.DTO
{
    public class BidCreateDto
    {
        [Required(ErrorMessage = "Amount is required.")]
        [Range(1, 1_000_000, ErrorMessage = "Amount must be between 1 - 1000000.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "AdId required.")]
        public int AdId { get; set; }

        [Required(ErrorMessage = "UserId required.")]
        public int UserId { get; set; }
    }
}
