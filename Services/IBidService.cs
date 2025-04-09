using Microsoft.AspNetCore.JsonPatch;
using Services.DTO;

namespace Services
{
    public interface IBidService
    {
        Task<BidDto> CreateAsync(BidCreateDto newBidDto);
        Task<List<BidDto>> GetAllAsync();
        Task<BidDto?> GetByIdAsync(int id);
        Task<BidDto> UpdateAsync(BidUpdateDto updatedBidDto);
        Task<BidDto?> PatchAsync(int id, JsonPatchDocument<BidUpdateDto> patchDoc);
        Task<bool> DeleteAsync(int id);
    }
}
