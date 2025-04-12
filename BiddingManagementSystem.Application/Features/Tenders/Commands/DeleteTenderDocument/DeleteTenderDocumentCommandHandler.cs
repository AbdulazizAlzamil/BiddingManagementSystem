using MediatR;
using BiddingManagementSystem.Domain.Interfaces.Persistence;
using BiddingManagementSystem.Application.Interfaces;

namespace BiddingManagementSystem.Application.Features.Tenders.Commands.DeleteTenderDocument
{
    public class DeleteTenderDocumentCommandHandler : IRequestHandler<DeleteTenderDocumentCommand, bool>
    {
        private readonly ITenderRepository _tenderRepository;
        private readonly IFileStorageService _fileStorageService;

        public DeleteTenderDocumentCommandHandler(ITenderRepository tenderRepository, IFileStorageService fileStorageService)
        {
            _tenderRepository = tenderRepository;
            _fileStorageService = fileStorageService;
        }

        public async Task<bool> Handle(DeleteTenderDocumentCommand command, CancellationToken cancellationToken)
        {
            var tender = await _tenderRepository.GetByDocumentIdAsync(command.DocumentId);
            var document = tender?.Documents.FirstOrDefault(d => d.Id == command.DocumentId);

            if (document == null || tender.UserId != command.UserId)
                return false;

            if (!string.IsNullOrEmpty(document.FilePath) && await _fileStorageService.FileExistsAsync(document.FilePath))
            {
                await _fileStorageService.DeleteFileAsync(document.FilePath);
            }

            tender.RemoveDocument(document);
            await _tenderRepository.UpdateAsync(tender);

            return true;
        }
    }
}
