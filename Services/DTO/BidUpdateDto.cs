using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class BidUpdateDto
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(1, 1_000_000, ErrorMessage = "Amount must be between 1 - 1000000.")]
        public decimal Amount { get; set; }
    }

}
