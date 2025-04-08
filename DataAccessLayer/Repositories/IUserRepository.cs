using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IUserRepository
    {
        //Task<User> CreateAsync(User user);
        Task<List<User>> GetAllAsync();
        //Task<User> GetByIdAsync(int id);
        //Task UpdateAsync(User user);
    }
}
