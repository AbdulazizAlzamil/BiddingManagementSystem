using MediatR;
using BiddingManagementSystem.Domain.Interfaces.Persistence;
using BiddingManagementSystem.Domain.Aggregates.TenderAggregate;

namespace BiddingManagementSystem.Application.Features.Bids.Queries.GetBidsByTender
{
    public class GetBidsByTenderQueryHandler : IRequestHandler<GetBidsByTenderQuery, IEnumerable<Bid>>
    {
        private readonly ITenderRepository _tenderRepository;

        public GetBidsByTenderQueryHandler(ITenderRepository tenderRepository)
        {
            _tenderRepository = tenderRepository;
        }

        public async Task<IEnumerable<Bid>> Handle(GetBidsByTenderQuery request, CancellationToken cancellationToken)
        {
            var tender = await _tenderRepository.GetByIdAsync(request.TenderId);
            if (tender == null) throw new ArgumentException("Tender not found.");

            return tender.Bids;
        }
    }
}

