using MediatR;
using BiddingManagementSystem.Domain.Interfaces.Persistence;

namespace BiddingManagementSystem.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username);
            if(user == null) throw new KeyNotFoundException("User not found");

            await _userRepository.DeleteAsync(user.Id);

            return Unit.Value;
        }
    }
}
