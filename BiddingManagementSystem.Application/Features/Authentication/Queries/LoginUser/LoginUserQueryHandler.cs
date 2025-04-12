using BiddingManagementSystem.Application.Contracts.Authentication;
using BiddingManagementSystem.Application.Interfaces;
using BiddingManagementSystem.Domain.Interfaces.Persistence;
using MediatR;

namespace BiddingManagementSystem.Application.Features.Authentication.Queries.LoginUser
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationProvider _authenticationProvider;

        public LoginUserQueryHandler(IUserRepository userRepository, IAuthenticationProvider authenticationProvider)
        {
            _userRepository = userRepository;
            _authenticationProvider = authenticationProvider;
        }

        public async Task<LoginUserResponse> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username);

            if(user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            var token = _authenticationProvider.GenerateToken(user);

            return new LoginUserResponse
            {
                Token = token,
            };
        }
    }
}

