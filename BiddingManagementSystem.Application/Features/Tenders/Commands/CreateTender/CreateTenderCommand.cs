using BiddingManagementSystem.Application.Contracts.Tenders;
using MediatR;

namespace BiddingManagementSystem.Application.Features.Tenders.Commands;

public class CreateTenderCommand : IRequest<TenderResponse>
{
    public CreateTenderRequest Request { get; }
    public int UserId { get; }

    public CreateTenderCommand(CreateTenderRequest request, int userId)
    {
        Request = request;
        UserId = userId;
    }
}