using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IBidRepository
    {
        Task<List<Bid>> GetAllAsync();
        Task<Bid> GetByIdAsync(int id);
    }
}
