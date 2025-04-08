using AutoMapper;
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
    }
}
