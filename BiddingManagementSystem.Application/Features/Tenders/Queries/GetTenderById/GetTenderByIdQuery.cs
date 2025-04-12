using BiddingManagementSystem.Application.Contracts.Tenders;
using MediatR;

namespace BiddingManagementSystem.Application.Features.Tenders.Queries;

public class GetTenderByIdQuery : IRequest<TenderResponse>
{
    public int Id { get; set; }

    public GetTenderByIdQuery(int id)
    {
        Id = id;
    }
}