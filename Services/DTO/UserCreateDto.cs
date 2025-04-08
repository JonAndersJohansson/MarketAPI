using System.ComponentModel.DataAnnotations;

namespace Services.DTO
{
    public class UserCreateDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 - 100 letters.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email-address.")]
        public string Email { get; set; } = null!;
    }
}
