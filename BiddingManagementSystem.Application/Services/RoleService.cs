using BiddingManagementSystem.Application.Interfaces;
using BiddingManagementSystem.Domain.Interfaces.Persistence;
using BiddingManagementSystem.Domain.Enums;

namespace BiddingManagementSystem.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUserRepository _userRepository;

        public RoleService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AssignRoleToUserAsync(int userId, RoleType roleType)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) throw new KeyNotFoundException("User not found.");

            var role = await _userRepository.GetRoleByNameAsync(roleType.ToString());
            if (role == null)
            {
                throw new InvalidOperationException($"Role '{roleType}' does not exist in the database.");
            }

            if (user.HasRole(roleType))
            {
                throw new InvalidOperationException($"User already has the role '{roleType}'.");
            }

            user.AddRole(role);

            await _userRepository.UpdateAsync(user);
        }

        public async Task<bool> CheckRoleAsync(int userId, RoleType roleType)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) throw new KeyNotFoundException("User not found.");

            return user.HasRole(roleType);
        }

        public async Task AssignRoleToUserAsync(int userId, string roleName)
        {
            if (!Enum.TryParse<RoleType>(roleName, out var roleType))
            {
                throw new ArgumentException($"Invalid role name: {roleName}");
            }

            await AssignRoleToUserAsync(userId, roleType);
        }

        public async Task<bool> CheckRoleAsync(int userId, string roleName)
        {
            if (!Enum.TryParse<RoleType>(roleName, out var roleType))
            {
                throw new ArgumentException($"Invalid role name: {roleName}");
            }

            return await CheckRoleAsync(userId, roleType);
        }
    }
}
