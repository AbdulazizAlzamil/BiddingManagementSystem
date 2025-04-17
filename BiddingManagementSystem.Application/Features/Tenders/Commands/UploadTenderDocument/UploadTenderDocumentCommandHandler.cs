using BiddingManagementSystem.Application.Interfaces;
using BiddingManagementSystem.Domain.Interfaces.Persistence;
using MediatR;

namespace BiddingManagementSystem.Application.Features.Tenders.Commands.UploadTenderDocument
{
    public class UploadTenderDocumentCommandHandler : IRequestHandler<UploadTenderDocumentCommand, bool>
    {
        private readonly ITenderRepository _tenderRepository;
        private readonly ITenderService _tenderService;
        private readonly IEmailService _emailService;
        private readonly IFileStorageService _fileStorageService;

        public UploadTenderDocumentCommandHandler(ITenderRepository tenderRepository, IEmailService emailService, ITenderService tenderService, IFileStorageService fileStorageService)
        {
            _tenderRepository = tenderRepository;
            _emailService = emailService;
            _tenderService = tenderService;
            _fileStorageService = fileStorageService;
        }

        public async Task<bool> Handle(UploadTenderDocumentCommand command, CancellationToken cancellationToken)
        {
            var tender = await _tenderRepository.GetByIdAsync(command.TenderId);

            var filePath = await _fileStorageService.SaveFileAsync(command.File, "TenderDocuments");

            var bidderEmails = tender.Bids.Select(b => b.User.Email).Distinct().ToList();
            await _emailService.SendBulkEmailAsync(
                bidderEmails,
                "New Document Uploaded",
                $"A new document has been uploaded for the tender '{tender.Title}'. Please check the details."
            );

            return await _tenderService.UploadTenderDocumentAsync(command.TenderId, filePath);
        }
    }
}