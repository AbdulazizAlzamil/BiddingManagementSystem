using MediatR;
using BiddingManagementSystem.Domain.ValueObjects;

namespace BiddingManagementSystem.Application.Features.Users.Commands.UpdateUserAddress
{
    public class UpdateUserAddressCommand : IRequest<Unit>
    {
        public string Username { get; set; }
        public Address NewAddress { get; }

        public UpdateUserAddressCommand(string username, Address newAddress)
        {
            Username = username;
            NewAddress = newAddress;
        }
    }
}
