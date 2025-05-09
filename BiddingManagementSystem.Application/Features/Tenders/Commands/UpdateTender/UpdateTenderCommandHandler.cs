using BiddingManagementSystem.Domain.Aggregates.TenderAggregate;
using BiddingManagementSystem.Domain.Interfaces.Persistence;
using BiddingManagementSystem.Application.Interfaces;
using MediatR;

namespace BiddingManagementSystem.Application.Features.Tenders.Commands.UpdateTender
{
    public class UpdateTenderCommandHandler : IRequestHandler<UpdateTenderCommand, bool>
    {
        private readonly ITenderRepository _tenderRepository;
        private readonly IEmailService _emailService;

        public UpdateTenderCommandHandler(ITenderRepository tenderRepository, IEmailService emailService)
        {
            _tenderRepository = tenderRepository;
            _emailService = emailService;
        }

        public async Task<bool> Handle(UpdateTenderCommand command, CancellationToken cancellationToken)
        {
            var tender = await _tenderRepository.GetByIdAsync(command.Id);
            if (tender == null || tender.UserId != command.UserId)
                return false;

            var categories = command.Request.Categories.Select(categoryDto => new TenderCategory
            {
                Name = categoryDto.Name,
                Industry = categoryDto.Industry,
                Type = categoryDto.Type,
                Location = categoryDto.Location
            }).ToList();

            tender.UpdateDetails(
                command.Request.Title,
                command.Request.Description,
                command.Request.DateRange,
                command.Request.Budget,
                command.Request.EligibilityCriteria,
                command.Request.Status,
                categories
            );

            await _tenderRepository.UpdateAsync(tender);

            var bidderEmails = tender.Bids.Select(b => b.User.Email).Distinct().ToList();
            await _emailService.SendBulkEmailAsync(
                bidderEmails,
                "Tender Updated",
                $"The tender '{tender.Title}' has been updated. Please check the details."
            );

            return true;
        }
    }
}