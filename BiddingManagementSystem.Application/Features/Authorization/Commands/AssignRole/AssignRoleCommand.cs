using BiddingManagementSystem.Domain.Enums;
using MediatR;

namespace BiddingManagementSystem.Application.Features.Authorization.Commands.AssignRole
{
    public class AssignRoleCommand : IRequest<Unit>
    {
        public int UserId { get; set; }
        public string RoleName { get; set; }
        public RoleType? RoleType { get; set; }
    }
}

