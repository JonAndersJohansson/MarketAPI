using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Services.DTO;

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

        public async Task<AdDto?> GetByIdAsync(int id)
        {
            var ad = await _repo.GetByIdAsync(id);
            return _mapper.Map<AdDto>(ad);
        }
        public async Task<AdDto> CreateAsync(AdCreateDto createdDto)
        {
            var ad = _mapper.Map<Ad>(createdDto);
            var createdAd = await _repo.CreateAsync(ad);
            return _mapper.Map<AdDto>(createdAd);
        }
    }

}
