using MediatR;
using BiddingManagementSystem.Application.Interfaces;

namespace BiddingManagementSystem.Application.Features.Bids.Commands.UploadBidDocument
{
    public class UploadBidDocumentCommandHandler : IRequestHandler<UploadBidDocumentCommand, bool>
    {
        private readonly IFileStorageService _fileStorageService;
        private readonly IBidService _bidService;

        public UploadBidDocumentCommandHandler(IFileStorageService fileStorageService, IBidService bidService)
        {
            _fileStorageService = fileStorageService;
            _bidService = bidService;
        }

        public async Task<bool> Handle(UploadBidDocumentCommand command, CancellationToken cancellationToken)
        {
            var filePath = await _fileStorageService.SaveFileAsync(command.File, "BidDocuments");
            return await _bidService.UploadBidDocumentAsync(command.BidId, filePath);
        }
    }
}
