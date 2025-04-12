using MediatR;

namespace BiddingManagementSystem.Application.Features.Users.Commands.DeleteUser
{
    public record DeleteUserCommand(string Username) : IRequest<Unit>;
}
