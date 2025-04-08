using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IAdRepository
    {
        Task<Ad> CreateAsync(Ad ad);
        Task<List<Ad>> GetAllAsync();
        Task<Ad> GetByIdAsync(int id);
    }

}
