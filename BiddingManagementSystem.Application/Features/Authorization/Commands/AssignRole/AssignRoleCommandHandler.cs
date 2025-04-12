using MediatR;
using BiddingManagementSystem.Application.Interfaces;
using BiddingManagementSystem.Domain.Enums;

namespace BiddingManagementSystem.Application.Features.Authorization.Commands.AssignRole;

public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommand, Unit>
{
    private readonly IRoleService _roleService;

    public AssignRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<Unit> Handle(AssignRoleCommand request, CancellationToken cancellationToken)
    {
        if(string.IsNullOrWhiteSpace(request.RoleName))
        {
            throw new ArgumentException("Role name cannot be null or empty.");
        }

        await _roleService.AssignRoleToUserAsync(request.UserId, request.RoleName);
        return Unit.Value;
    }
}
