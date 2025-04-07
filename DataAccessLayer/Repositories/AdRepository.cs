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
    public class AdRepository : IAdRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AdRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Ad>> GetAllAsync()
        {
            return await _dbContext.Ads
                .Include(a => a.Creator)
                .Where(a => a.IsActive)
                .ToListAsync();
        }
    }

}
