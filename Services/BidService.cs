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
    }
}
