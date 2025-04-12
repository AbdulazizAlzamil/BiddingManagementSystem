using BiddingManagementSystem.Application.Contracts.Authentication;
using MediatR;

namespace BiddingManagementSystem.Application.Features.Authentication.Queries.LoginUser
{
    public class LoginUserQuery : IRequest<LoginUserResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
