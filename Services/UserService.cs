using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Services.DTO;
using Services.Helpers;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _userRepo.GetAllAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {

            var user = await _userRepo.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateAsync(UserCreateDto userCreateDto)
        {
            var user = _mapper.Map<User>(userCreateDto);
            var createdUser = await _userRepo.CreateAsync(user);
            return _mapper.Map<UserDto>(createdUser);
        }

        public async Task<UserDto> UpdateAsync(UserUpdateDto updatedUserDto)
        {
            var existingUser = await _userRepo.GetByIdAsync(updatedUserDto.Id);
            if (existingUser == null)
            {
                return null;
            }
            _mapper.Map(updatedUserDto, existingUser);
            await _userRepo.UpdateAsync(existingUser);
            return _mapper.Map<UserDto>(existingUser);
        }

        public async Task<UserDto?> PatchAsync(int id, JsonPatchDocument<UserUpdateDto> patchDoc)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null || !user.IsActive)
                return null;

            var userDto = _mapper.Map<UserUpdateDto>(user);

            PatchHelper.ApplyPatch(patchDoc, userDto, "/id");

            _mapper.Map(userDto, user);
            await _userRepo.UpdateAsync(user);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null)
            {
                return false;
            }
            user.IsActive = false;
            await _userRepo.UpdateAsync(user);
            return true;
        }
    }
}
