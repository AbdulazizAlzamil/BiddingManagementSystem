using MediatR;
using BiddingManagementSystem.Domain.Interfaces.Persistence;

namespace BiddingManagementSystem.Application.Features.Bids.Commands.DeleteBid
{
    public class DeleteBidCommandHandler : IRequestHandler<DeleteBidCommand, bool>
    {
        private readonly ITenderRepository _tenderRepository;

        public DeleteBidCommandHandler(ITenderRepository tenderRepository)
        {
            _tenderRepository = tenderRepository;
        }

        public async Task<bool> Handle(DeleteBidCommand command, CancellationToken cancellationToken)
        {
            var tender = await _tenderRepository.GetByBidIdAsync(command.BidId);
            var bid = tender?.Bids.FirstOrDefault(b => b.Id == command.BidId);

            if (bid == null || bid.UserId != command.UserId)
                return false;

            tender.RemoveBid(bid);
            await _tenderRepository.UpdateAsync(tender);

            return true;
        }
    }
}
