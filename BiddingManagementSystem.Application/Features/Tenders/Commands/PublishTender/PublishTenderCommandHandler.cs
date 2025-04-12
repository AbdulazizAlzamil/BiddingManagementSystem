using BiddingManagementSystem.Domain.Aggregates.TenderAggregate;
using BiddingManagementSystem.Domain.Enums;
using BiddingManagementSystem.Domain.Interfaces.Persistence;
using MediatR;

namespace BiddingManagementSystem.Application.Features.Tenders.Commands.PublishTender
{
    public class PublishTenderCommandHandler : IRequestHandler<PublishTenderCommand, bool>
    {
        private readonly ITenderRepository _tenderRepository;

        public PublishTenderCommandHandler(ITenderRepository tenderRepository)
        {
            _tenderRepository = tenderRepository;
        }

        public async Task<bool> Handle(PublishTenderCommand command, CancellationToken cancellationToken)
        {
            var tender = await _tenderRepository.GetByIdAsync(command.Id);
            if(tender == null) return false;

            tender.UpdateDetails(
                tender.Title,
                tender.Description,
                tender.DateRange,
                tender.Budget,
                tender.EligibilityCriteria,
                TenderStatus.Published,
                tender.Categories
            );

            await _tenderRepository.UpdateAsync(tender);
            return true;
        }
    }
}
