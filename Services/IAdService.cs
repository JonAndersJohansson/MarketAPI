using Services.DTO;

namespace Services
{
    public interface IAdService
    {
        Task<List<AdDto>> GetAllAsync();
        Task<AdDto?> GetByIdAsync(int id);
        Task<AdDto> CreateAsync(AdCreateDto dto);
        Task<AdDto> UpdateAsync(AdUpdateDto updatedAdDto);
        Task<bool> DeleteAsync(int id);
    }
}
