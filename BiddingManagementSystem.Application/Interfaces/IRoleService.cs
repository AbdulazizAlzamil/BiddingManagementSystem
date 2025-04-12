namespace BiddingManagementSystem.Application.Interfaces
{
    public interface IRoleService
    {
        Task AssignRoleToUserAsync(int userId, string roleName);
        Task<bool> CheckRoleAsync(int userId, string roleName);
    }
}
