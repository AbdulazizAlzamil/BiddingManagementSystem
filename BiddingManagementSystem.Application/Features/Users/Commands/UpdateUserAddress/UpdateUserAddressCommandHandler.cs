using MediatR;
using BiddingManagementSystem.Domain.Interfaces.Persistence;

namespace BiddingManagementSystem.Application.Features.Users.Commands.UpdateUserAddress
{
    public class UpdateUserAddressCommandHandler : IRequestHandler<UpdateUserAddressCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserAddressCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(UpdateUserAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username);
            if (user == null) throw new KeyNotFoundException("User not found");

            var currentAddress = user.Address;

            if (request.NewAddress.Street != null) currentAddress.Street = request.NewAddress.Street;
            if (request.NewAddress.City != null) currentAddress.City = request.NewAddress.City;
            if (request.NewAddress.State != null) currentAddress.State = request.NewAddress.State;
            if (request.NewAddress.PostalCode != null) currentAddress.PostalCode = request.NewAddress.PostalCode;
            if (request.NewAddress.Country != null) currentAddress.Country = request.NewAddress.Country;

            user.UpdateAddress(currentAddress);
            await _userRepository.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
