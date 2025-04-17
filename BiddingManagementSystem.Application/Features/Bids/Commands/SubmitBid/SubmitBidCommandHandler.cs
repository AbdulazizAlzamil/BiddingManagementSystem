using MediatR;
using BiddingManagementSystem.Domain.Interfaces.Persistence;
using BiddingManagementSystem.Domain.Aggregates.TenderAggregate;
using BiddingManagementSystem.Domain.Enums;

namespace BiddingManagementSystem.Application.Features.Bids.Commands.SubmitBid
{
    public class SubmitBidCommandHandler : IRequestHandler<SubmitBidCommand, Unit>
    {
        private readonly ITenderRepository _tenderRepository;
        private readonly IUserRepository _userRepository;

        public SubmitBidCommandHandler(ITenderRepository tenderRepository, IUserRepository userRepository)
        {
            _tenderRepository = tenderRepository;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(SubmitBidCommand request, CancellationToken cancellationToken)
        {
            var tender = await _tenderRepository.GetByIdAsync(request.TenderId);
            if (tender == null) throw new ArgumentException("Tender not found.");

            if (tender.Status != TenderStatus.Published)
                throw new InvalidOperationException("Bids can only be submitted to published tenders.");

            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null) throw new ArgumentException("User not found.");

            var bid = Bid.Create(request.TenderId, request.UserId, request.Amount, BidStatus.Submitted);

            user.AddBid(bid);
            tender.AddBid(bid);

            await _tenderRepository.UpdateAsync(tender);
            return Unit.Value;
        }
    }
}

