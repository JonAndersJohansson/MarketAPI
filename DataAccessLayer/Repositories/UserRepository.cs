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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users
                .Include(u => u.Bids)
                .Include(u => u.Ads)
                .Where(u => u.IsActive)
                .ToListAsync();
        }
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _dbContext.Users
                .Include(u => u.Bids)
                .Include(u => u.Ads)
                .FirstOrDefaultAsync(u => u.Id == id && u.IsActive);
        }

    }
}
