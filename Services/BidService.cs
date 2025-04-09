using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Services.DTO;

namespace Services
{
    public class BidService : IBidService
    {
        private readonly IBidRepository _bidRepo;
        private readonly IUserRepository _userRepo;
        private readonly IAdRepository _adRepo;
        private readonly IMapper _mapper;

        public BidService(IBidRepository bidRepo, IUserRepository userRepo, IAdRepository adRepo, IMapper mapper)
        {
            _bidRepo = bidRepo;
            _userRepo = userRepo;
            _adRepo = adRepo;
            _mapper = mapper;
        }
        public async Task<List<BidDto>> GetAllAsync()
        {
            var bids = await _bidRepo.GetAllAsync();
            return _mapper.Map<List<BidDto>>(bids);
        }

        public async Task<BidDto?> GetByIdAsync(int id)
        {
            var bid = await _bidRepo.GetByIdAsync(id);
            return _mapper.Map<BidDto>(bid);
        }

        public async Task<BidDto> CreateAsync(BidCreateDto newBidDto)
        {
            if (newBidDto.AdId <= 0)
                throw new ArgumentException("AdId must be greater than 0");
            if (newBidDto.UserId <= 0)
                throw new ArgumentException("UserId must be greater than 0");

            var user = await _userRepo.GetByIdAsync(newBidDto.UserId);
            if (user == null || !user.IsActive)
                throw new ArgumentException("UserId not found or invalid");

            var ad = await _adRepo.GetByIdAsync(newBidDto.AdId);
            if (ad == null || !ad.IsActive)
                throw new ArgumentException("AdId not found or invalid");

            var bid = _mapper.Map<Bid>(newBidDto);
            bid.UserId = user.Id;
            bid.AdId = ad.Id;

            var createdBid = await _bidRepo.CreateAsync(bid);
            return _mapper.Map<BidDto>(createdBid);
        }

        public async Task<BidDto?> UpdateAsync(BidUpdateDto updatedBidDto)
        {
            var existingBid = await _bidRepo.GetByIdAsync(updatedBidDto.Id);

            if (existingBid == null || !existingBid.IsActive)
                return null;

            _mapper.Map(updatedBidDto, existingBid);

            await _bidRepo.UpdateAsync(existingBid);

            return _mapper.Map<BidDto>(existingBid);
        }

        public async Task<BidDto?> PatchAsync(int id, JsonPatchDocument<BidUpdateDto> patchDoc)
        {
            var bid = await _bidRepo.GetByIdAsync(id);
            if (bid == null || !bid.IsActive)
                return null;

            var bidToPatch = _mapper.Map<BidUpdateDto>(bid);

            patchDoc.ApplyTo(bidToPatch);

            _mapper.Map(bidToPatch, bid);
            await _bidRepo.UpdateAsync(bid);

            return _mapper.Map<BidDto>(bid);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var bid = await _bidRepo.GetByIdAsync(id);
            if (bid == null)
                return false;
            bid.IsActive = false;
            await _bidRepo.UpdateAsync(bid);
            return true;
        }
    }
}
