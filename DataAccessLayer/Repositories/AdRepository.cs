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
        public async Task<Ad?> GetByIdAsync(int id)
        {
            return await _dbContext.Ads
                .Include(a => a.Creator)
                .FirstOrDefaultAsync(a => a.Id == id && a.IsActive);
        }
        public async Task<Ad> CreateAsync(Ad ad)
        {
            ad.CreatedAt = DateTime.UtcNow;
            ad.IsActive = true;
            await _dbContext.Ads.AddAsync(ad);
            await _dbContext.SaveChangesAsync();
            var createdAd = await _dbContext.Ads
                .Include(a => a.Creator)
                .FirstOrDefaultAsync(a => a.Id == ad.Id);

            if (createdAd == null)
                throw new Exception("Failed to reload Ad after saving.");

            return createdAd;
        }
    }

}
