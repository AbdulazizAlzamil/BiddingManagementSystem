using MediatR;

namespace BiddingManagementSystem.Application.Features.Bids.Commands.DeleteBidDocument
{
    public class DeleteBidDocumentCommand : IRequest<bool>
    {
        public int BidId { get; set; }
        public int DocumentId { get; set; }
        public int UserId { get; set; }

        public DeleteBidDocumentCommand(int bidId, int documentId, int userId)
        {
            BidId = bidId;
            DocumentId = documentId;
            UserId = userId;
        }
    }
}
