using Services.DTO;

namespace Services
{
    public interface IAdService
    {
        Task<List<AdDto>> GetAllAsync();
        Task<AdDto?> GetByIdAsync(int id);
        Task<AdDto> CreateAsync(AdCreateDto dto);
        //Task<bool> UpdateAsync(AdUpdateDto dto);
        //Task<bool> DeleteAsync(int id);
        //Task<bool> PatchTitleAsync(int id, string newTitle);
    }
}
