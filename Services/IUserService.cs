using Microsoft.AspNetCore.JsonPatch;
using Services.DTO;

namespace Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task<UserDto> CreateAsync(UserCreateDto userCreateDto);
        Task<UserDto> UpdateAsync(UserUpdateDto updatedUserDto);
        Task<UserDto?> PatchAsync(int id, JsonPatchDocument<UserUpdateDto> patchDoc);
        Task<bool> DeleteAsync(int id);
    }
}
