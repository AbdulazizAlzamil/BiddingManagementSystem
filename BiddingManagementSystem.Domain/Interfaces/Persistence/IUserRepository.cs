using BiddingManagementSystem.Domain.Aggregates.UserAggregate;

namespace BiddingManagementSystem.Domain.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetByUsernameAsync(string username);
        Task<User> GetByIdAsync(int userId);
        Task UpdateAsync(User user);
        Task DeleteAsync(int userId);

        Task<User> GetByEmailAsync(string email);

        Task<Role> GetRoleByNameAsync(string roleName);
    }
}
