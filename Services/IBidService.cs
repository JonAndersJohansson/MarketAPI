using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBidService
    {
        Task<BidDto> CreateAsync(BidCreateDto newBidDto);
        Task<List<BidDto>> GetAllAsync();
        Task<BidDto?> GetByIdAsync(int id);
    }
}
