namespace BiddingManagementSystem.Domain.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
