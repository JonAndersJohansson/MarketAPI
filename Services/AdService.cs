using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Services.DTO;

namespace Services
{
    public class AdService : IAdService
    {
        private readonly IAdRepository _adRepo;
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public AdService(IAdRepository adRepo, IUserRepository userRepo, IMapper mapper)
        {
            _adRepo = adRepo;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<List<AdDto>> GetAllAsync()
        {
            var ads = await _adRepo.GetAllAsync();
            return _mapper.Map<List<AdDto>>(ads);
        }

        public async Task<AdDto?> GetByIdAsync(int id)
        {
            var ad = await _adRepo.GetByIdAsync(id);
            return _mapper.Map<AdDto>(ad);
        }

        public async Task<AdDto?> CreateAsync(AdCreateDto createdDto)
        {
            if (createdDto.CreatorId <= 0)
                throw new ArgumentException("CreatorId must be greater than 0");

            var user = await _userRepo.GetByIdAsync(createdDto.CreatorId);
            if (user == null || !user.IsActive)
                throw new ArgumentException("CreatorId not found or invalid");

            var ad = _mapper.Map<Ad>(createdDto);
            ad.CreatorId = user.Id;

            var createdAd = await _adRepo.CreateAsync(ad);
            return _mapper.Map<AdDto>(createdAd);
        }

        public async Task<AdDto?> UpdateAsync(AdUpdateDto updatedAdDto)
        {
            var existingAd = await _adRepo.GetByIdAsync(updatedAdDto.Id);
            if (existingAd == null || !existingAd.IsActive)
                return null;

            _mapper.Map(updatedAdDto, existingAd);
            await _adRepo.UpdateAsync(existingAd);

            return _mapper.Map<AdDto>(existingAd);
        }

        public async Task<AdDto?> PatchAsync(int id, JsonPatchDocument<AdUpdateDto> patchDoc)
        {
            var ad = await _adRepo.GetByIdAsync(id);
            if (ad == null || !ad.IsActive)
                return null;

            var adToPatch = _mapper.Map<AdUpdateDto>(ad);

            patchDoc.ApplyTo(adToPatch);

            _mapper.Map(adToPatch, ad);
            await _adRepo.UpdateAsync(ad);

            return _mapper.Map<AdDto>(ad);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ad = await _adRepo.GetByIdAsync(id);
            if (ad == null)
                return false;
            ad.IsActive = false;
            await _adRepo.UpdateAsync(ad);
            return true;
        }
    }
}
