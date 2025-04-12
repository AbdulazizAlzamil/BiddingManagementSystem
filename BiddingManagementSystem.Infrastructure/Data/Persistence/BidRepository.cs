using BiddingManagementSystem.Domain.Interfaces.Persistence;
using BiddingManagementSystem.Domain.Aggregates.UserAggregate;
using Microsoft.EntityFrameworkCore;
using BiddingManagementSystem.Domain.Aggregates.TenderAggregate;

namespace BiddingManagementSystem.Infrastructure.Data.Persistence
{
    public class BidRepository : Repository<Bid>, IBidRepository
    {
        private readonly AppDbContext _context;

        public BidRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bid>> GetByUserIdAsync(int userId)
        {
            return await _context.Set<Bid>().Where(b => b.UserId == userId).ToListAsync();
        }
    }
}
