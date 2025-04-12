using BiddingManagementSystem.Application.Contracts.Tenders;
using BiddingManagementSystem.Domain.Aggregates.TenderAggregate;
using BiddingManagementSystem.Domain.Enums;
using BiddingManagementSystem.Domain.Interfaces.Persistence;
using MediatR;

namespace BiddingManagementSystem.Application.Features.Tenders.Commands;

public class UpdateTenderCommand : IRequest<bool>
{
    public int Id { get; }
    public UpdateTenderRequest Request { get; }
    public int UserId { get; }

    public UpdateTenderCommand(int id, UpdateTenderRequest request, int userId)
    {
        Id = id;
        Request = request;
        UserId = userId;
    }
}