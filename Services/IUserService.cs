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
        //Task<UserDto> CreateUserAsync(UserCreateDto userCreateDto);
        //Task<UserDto> UpdateUserAsync(int id, UserUpdateDto userUpdateDto);
        //Task<bool> DeleteUserAsync(int id);
    }
}
