using MediatR;

namespace BiddingManagementSystem.Application.Features.Bids.Commands.DeleteBid
{
    public class DeleteBidCommand : IRequest<bool>
    {
        public int BidId { get; set; }
        public int UserId { get; set; }

        public DeleteBidCommand(int bidId, int userId)
        {
            BidId = bidId;
            UserId = userId;
        }
    }
}
