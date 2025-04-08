using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task<UserDto> CreateAsync(UserCreateDto userCreateDto);
        Task<UserDto> UpdateAsync(UserUpdateDto updatedUserDto);
        Task<bool> DeleteAsync(int id);
    }
}
