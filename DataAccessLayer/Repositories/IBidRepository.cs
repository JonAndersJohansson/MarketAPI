using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public interface IBidRepository
    {
        Task<Bid> CreateAsync(Bid bid);
        Task<List<Bid>> GetAllAsync();
        Task<Bid> GetByIdAsync(int id);
        Task UpdateAsync(Bid bid);
    }
}
