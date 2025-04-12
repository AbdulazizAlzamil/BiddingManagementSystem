using BiddingManagementSystem.Application.Interfaces;
using MediatR;

namespace BiddingManagementSystem.Application.Features.Tenders.Commands.UploadTenderDocument
{
    public class UploadTenderDocumentCommandHandler : IRequestHandler<UploadTenderDocumentCommand, bool>
    {
        private readonly ITenderService _tenderService;
        private readonly IFileStorageService _fileStorageService;

        public UploadTenderDocumentCommandHandler(ITenderService tenderService, IFileStorageService fileStorageService)
        {
            _tenderService = tenderService;
            _fileStorageService = fileStorageService;
        }

        public async Task<bool> Handle(UploadTenderDocumentCommand command, CancellationToken cancellationToken)
        {
            var filePath = await _fileStorageService.SaveFileAsync(command.File, "TenderDocuments");
            return await _tenderService.UploadTenderDocumentAsync(command.TenderId, filePath);
        }
    }
}