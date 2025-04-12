using BiddingManagementSystem.Application.Interfaces;
using BiddingManagementSystem.Domain.Interfaces.Persistence;
using MediatR;

namespace BiddingManagementSystem.Application.Features.Authentication.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public ResetPasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
            {
                throw new KeyNotFoundException("User with the provided email does not exist.");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.OldPassword, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("The old password is incorrect.");
            }

            if (request.NewPassword != request.ConfirmPassword)
            {
                throw new ArgumentException("The new password and confirmation password do not match.");
            }

            user.ChangePassword(BCrypt.Net.BCrypt.HashPassword(request.NewPassword));
            await _userRepository.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
