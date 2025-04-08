using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _repo.GetAllAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {

            var user = await _repo.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            return _mapper.Map<UserDto>(user);
        }
        public async Task<UserDto> CreateAsync(UserCreateDto userCreateDto)
        {
            var user = _mapper.Map<User>(userCreateDto);
            var createdUser = await _repo.CreateAsync(user);
            return _mapper.Map<UserDto>(createdUser);
        }

        public async Task<UserDto> UpdateAsync(UserUpdateDto updatedUserDto)
        {
            var existingUser = await _repo.GetByIdAsync(updatedUserDto.Id);
            if (existingUser == null)
            {
                return null;
            }
            _mapper.Map(updatedUserDto, existingUser);
            await _repo.UpdateAsync(existingUser);
            return _mapper.Map<UserDto>(existingUser);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null)
            {
                return false;
            }
            user.IsActive = false;
            await _repo.UpdateAsync(user);
            return true;
        }
    }
}
