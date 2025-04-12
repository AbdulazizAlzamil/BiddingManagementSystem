using BiddingManagementSystem.Application.Contracts.Users;
using MediatR;

namespace BiddingManagementSystem.Application.Features.Users.Commands.GetUserByUsername
{
    public record GetUserByUsernameQuery(string Username) : IRequest<UserResponse>;
}
