using MediatR;
using Microsoft.AspNetCore.Http;

namespace BiddingManagementSystem.Application.Features.Bids.Commands.UploadBidDocument
{
    public class UploadBidDocumentCommand : IRequest<bool>
    {
        public int BidId { get; }
        public IFormFile File { get; }

        public UploadBidDocumentCommand(int bidId, IFormFile file)
        {
            BidId = bidId;
            File = file;
        }
    }
}
