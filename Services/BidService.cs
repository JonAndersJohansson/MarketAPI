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
    public class BidService : IBidService
    {
        private readonly IBidRepository _repo;
        private readonly IMapper _mapper;

        public BidService(IBidRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<List<BidDto>> GetAllAsync()
        {
            var bids = await _repo.GetAllAsync();
            return _mapper.Map<List<BidDto>>(bids);
        }

        public async Task<BidDto?> GetByIdAsync(int id)
        {
            var bid = await _repo.GetByIdAsync(id);
            return _mapper.Map<BidDto>(bid);
        }

        public async Task<BidDto> CreateAsync(BidCreateDto newBidDto)
        {
            var bid = _mapper.Map<Bid>(newBidDto);
            var createdBid = await _repo.CreateAsync(bid);
            return _mapper.Map<BidDto>(createdBid);
        }

        public async Task<BidDto?> UpdateAsync(BidUpdateDto updatedBidDto)
        {
            var existingBid = await _repo.GetByIdAsync(updatedBidDto.Id);

            if (existingBid == null || !existingBid.IsActive)
                return null;

            _mapper.Map(updatedBidDto, existingBid);

            await _repo.UpdateAsync(existingBid);

            return _mapper.Map<BidDto>(existingBid);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var bid = await _repo.GetByIdAsync(id);
            if (bid == null)
                return false;
            bid.IsActive = false;
            await _repo.UpdateAsync(bid);
            return true;
        }
    }
}
