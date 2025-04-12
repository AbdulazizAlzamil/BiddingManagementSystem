using MediatR;
using BiddingManagementSystem.Domain.Interfaces.Persistence;

namespace BiddingManagementSystem.Application.Features.Users.Commands.UpdateUserEmail
{
    public class UpdateUserEmailCommandHandler : IRequestHandler<UpdateUserEmailCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserEmailCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(UpdateUserEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username);
            if(user == null) throw new KeyNotFoundException("User not found");

            user.UpdateEmail(request.NewEmail);
            await _userRepository.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
