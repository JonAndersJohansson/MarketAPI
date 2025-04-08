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

        public async Task<User> CreateAsync(User user)
        {
            user.IsActive = true;
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            var createdUser = await _dbContext.Users
                .Include(u => u.Bids)
                .Include(u => u.Ads)
                .FirstOrDefaultAsync(u => u.Id == user.Id);

            if (createdUser == null)
                throw new Exception("Failed to reload User after saving.");

            return createdUser;
        }
        public async Task UpdateAsync(User existingUser)
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}
