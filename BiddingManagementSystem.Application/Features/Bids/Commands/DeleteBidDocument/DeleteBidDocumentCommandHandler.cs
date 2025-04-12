using MediatR;
using BiddingManagementSystem.Domain.Interfaces.Persistence;
using BiddingManagementSystem.Application.Interfaces;
    
namespace BiddingManagementSystem.Application.Features.Bids.Commands.DeleteBidDocument
{
    public class DeleteBidDocumentCommandHandler : IRequestHandler<DeleteBidDocumentCommand, bool>
    {
        private readonly ITenderRepository _tenderRepository;
        private readonly IFileStorageService _fileStorageService;

        public DeleteBidDocumentCommandHandler(ITenderRepository tenderRepository, IFileStorageService fileStorageService)
        {
            _tenderRepository = tenderRepository;
            _fileStorageService = fileStorageService;
        }

        public async Task<bool> Handle(DeleteBidDocumentCommand command, CancellationToken cancellationToken)
        {
            var tender = await _tenderRepository.GetByBidIdAsync(command.BidId);
            var bid = tender?.Bids.FirstOrDefault(b => b.Id == command.BidId);
            var document = bid?.Documents.FirstOrDefault(d => d.Id == command.DocumentId);

            if (bid == null || document == null || bid.UserId != command.UserId)
                return false;

            if (!string.IsNullOrEmpty(document.FilePath) && await _fileStorageService.FileExistsAsync(document.FilePath))
            {
                await _fileStorageService.DeleteFileAsync(document.FilePath);
            }

            bid.Documents.Remove(document);
            await _tenderRepository.UpdateAsync(tender);

            return true;
        }
    }
}
