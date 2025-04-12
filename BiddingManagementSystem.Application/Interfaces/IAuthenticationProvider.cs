using BiddingManagementSystem.Domain.Aggregates.UserAggregate;
using System.Security.Claims;

namespace BiddingManagementSystem.Application.Interfaces
{
    public interface IAuthenticationProvider
    {
        string GenerateToken(User user);
        ClaimsPrincipal ValidateToken(string token);
    }
}

