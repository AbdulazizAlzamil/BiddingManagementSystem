using AutoMapper;
using MediatR;
using BiddingManagementSystem.Application.Contracts.Authentication;
using BiddingManagementSystem.Application.Interfaces;
using BiddingManagementSystem.Domain.Aggregates.UserAggregate;
using BiddingManagementSystem.Domain.Interfaces.Persistence;
using BiddingManagementSystem.Domain.ValueObjects;
using BiddingManagementSystem.Domain.Enums;

namespace BiddingManagementSystem.Application.Features.Authentication.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IAuthenticationProvider _authenticationProvider;
    private readonly IRoleService _roleService;

    public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper, IAuthenticationProvider authenticationProvider, IRoleService roleService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _authenticationProvider = authenticationProvider;
        _roleService = roleService;
    }

    public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        user.ChangePassword(BCrypt.Net.BCrypt.HashPassword(request.Password));
        
        if (user.Address == null)
        {
            user.UpdateAddress(new Address(
                request.Street ?? "Unknown",
                request.City ?? "Unknown",
                request.State ?? "Unknown",
                request.PostalCode ?? "Unknown",
                request.Country ?? "Unknown"
            ));
        }

        await _userRepository.AddAsync(user);

        await _roleService.AssignRoleToUserAsync(user.Id, RoleType.User.ToString());

        if (!user.Roles.Any())
        {
            throw new InvalidOperationException("User must have at least one role assigned.");
        }

        var token = _authenticationProvider.GenerateToken(user);

        return new RegisterUserResponse { UserId = user.Id, Token = token };
    }
}
