using BiddingManagementSystem.Domain.Aggregates.TenderAggregate;
using BiddingManagementSystem.Domain.Aggregates.UserAggregate;
using BiddingManagementSystem.Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BiddingManagementSystem.Infrastructure.Data.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public IRepository<User> UserRepository { get; }
        public IRepository<Bid> BidRepository { get; }
        public IRepository<Tender> TenderRepository { get; }

        public UnitOfWork(DbContext context)
        {
            _context = context;
            UserRepository = new Repository<User>(_context);
            BidRepository = new Repository<Bid>(_context);
            TenderRepository = new Repository<Tender>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}