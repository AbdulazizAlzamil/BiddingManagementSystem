using MediatR;
using BiddingManagementSystem.Domain.Interfaces.Persistence;
using BiddingManagementSystem.Application.Contracts.Bids;

namespace BiddingManagementSystem.Application.Features.Bids.Queries.GetBidsByTender
{
    public class GetBidsByTenderQueryHandler : IRequestHandler<GetBidsByTenderQuery, IEnumerable<BidResponse>>
    {
        private readonly ITenderRepository _tenderRepository;

        public GetBidsByTenderQueryHandler(ITenderRepository tenderRepository)
        {
            _tenderRepository = tenderRepository;
        }

        public async Task<IEnumerable<BidResponse>> Handle(GetBidsByTenderQuery request, CancellationToken cancellationToken)
        {
            var tender = await _tenderRepository.GetByIdAsync(request.TenderId);
            if (tender == null) throw new ArgumentException("Tender not found.");

            return tender.Bids.Select(bid => new BidResponse
            {
                TenderId = request.TenderId,
                UserId = bid.UserId,
                Amount = bid.Amount,
                BidDate = bid.BidDate,
                Status = bid.Status.ToString()
            });
        }
    }
}

