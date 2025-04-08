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
    }
}
