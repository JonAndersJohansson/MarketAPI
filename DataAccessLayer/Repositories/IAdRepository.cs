using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public interface IAdRepository
    {
        Task<Ad> CreateAsync(Ad ad);
        Task<List<Ad>> GetAllAsync();
        Task<Ad> GetByIdAsync(int id);
        Task UpdateAsync(Ad ad);
    }
}
