using AutoMapper;
using DataAccessLayer.DTO;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AdService : IAdService
    {
        private readonly IAdRepository _repo;
        private readonly IMapper _mapper;

        public AdService(IAdRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<AdDto>> GetAllAsync()
        {
            var ads = await _repo.GetAllAsync();
            return _mapper.Map<List<AdDto>>(ads);
        }

        //public async Task<AdDto?> GetByIdAsync(int id)
        //{
        //    var ad = await _repo.GetByIdAsync(id);
        //    return _mapper.Map<AdDto>(ad);
        //}
    }

}
