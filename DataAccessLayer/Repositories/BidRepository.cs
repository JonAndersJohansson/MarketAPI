using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BidRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Bid>> GetAllAsync()
        {
            return await _dbContext.Bids
                .Include(b => b.Ad)
                .Include(b => b.User)
                .Where(b => b.IsActive)
                .ToListAsync();
        }

        public async Task<Bid?> GetByIdAsync(int id)
        {
            return await _dbContext.Bids
                .Include(b => b.Ad)
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.Id == id && b.IsActive);
        }

        public async Task<Bid> CreateAsync(Bid bid)
        {
            bid.IsActive = true;
            await _dbContext.Bids.AddAsync(bid);
            await _dbContext.SaveChangesAsync();

            var createdBid = await _dbContext.Bids
                .Include(b => b.Ad)
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.Id == bid.Id);

            if (createdBid == null)
                throw new Exception("Failed to reload Bid after saving.");

            return createdBid;
        }

        public async Task UpdateAsync(Bid bid)
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
