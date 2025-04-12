using MediatR;
using BiddingManagementSystem.Domain.Aggregates.TenderAggregate;

namespace BiddingManagementSystem.Application.Features.Bids.Queries.GetBidsByTender
{
    public class GetBidsByTenderQuery : IRequest<IEnumerable<Bid>>
    {
        public int TenderId { get; set; }
    }
}

