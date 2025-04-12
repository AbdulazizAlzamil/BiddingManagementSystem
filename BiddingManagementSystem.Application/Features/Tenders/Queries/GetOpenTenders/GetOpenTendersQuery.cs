using MediatR;
using BiddingManagementSystem.Application.Contracts.Tenders;

namespace BiddingManagementSystem.Application.Features.Tenders.Queries.GetOpenTenders
{
    public class GetOpenTendersQuery : IRequest<IEnumerable<TenderResponse>>
    {
    }
}

