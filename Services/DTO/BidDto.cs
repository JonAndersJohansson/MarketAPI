using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class BidDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime BidTime { get; set; }
        public int AdId { get; set; }
        public string UserName { get; set; } = null!;
    }
}
