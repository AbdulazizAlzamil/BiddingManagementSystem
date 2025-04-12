using BiddingManagementSystem.Domain.Aggregates.TenderAggregate;

namespace BiddingManagementSystem.Domain.Interfaces.Persistence
{
    public interface IBidRepository
    {
        Task AddAsync(Bid bid);
        Task<Bid> GetByIdAsync(int bidId);
        Task<IEnumerable<Bid>> GetByUserIdAsync(int userId);
        Task UpdateAsync(Bid bid);
        Task DeleteAsync(int bidId);
    }
}
