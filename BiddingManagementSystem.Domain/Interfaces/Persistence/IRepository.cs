namespace BiddingManagementSystem.Domain.Interfaces.Persistence
{
    public interface IRepository<T>
    {
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync(T entity);
    }
}
