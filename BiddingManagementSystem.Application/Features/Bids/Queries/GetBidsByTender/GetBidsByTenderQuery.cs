using MediatR;
using BiddingManagementSystem.Domain.Aggregates.TenderAggregate;
using BiddingManagementSystem.Application.Contracts.Bids;

namespace BiddingManagementSystem.Application.Features.Bids.Queries.GetBidsByTender
{
    public class GetBidsByTenderQuery : IRequest<IEnumerable<BidResponse>>
    {
        public int TenderId { get; set; }
    }
}

