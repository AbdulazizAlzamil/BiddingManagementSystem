using MediatR;

namespace BiddingManagementSystem.Application.Features.Users.Commands.UpdateUserEmail
{
    public record UpdateUserEmailCommand(string Username, string NewEmail) : IRequest<Unit>;
}
