using BiddingManagementSystem.Application.Contracts.Tenders;
using BiddingManagementSystem.Domain.Aggregates.TenderAggregate;
using BiddingManagementSystem.Domain.Enums;
using BiddingManagementSystem.Domain.Interfaces.Persistence;
using MediatR;

namespace BiddingManagementSystem.Application.Features.Tenders.Commands.CreateTender
{
    public class CreateTenderCommandHandler : IRequestHandler<CreateTenderCommand, TenderResponse>
    {
        private readonly ITenderRepository _tenderRepository;

        public CreateTenderCommandHandler(ITenderRepository tenderRepository)
        {
            _tenderRepository = tenderRepository;
        }

        public async Task<TenderResponse> Handle(CreateTenderCommand command, CancellationToken cancellationToken)
        {
            var categories = command.Request.Categories
                .Select(categoryDto => new TenderCategory
                {
                    Name = categoryDto.Name,
                    Industry = categoryDto.Industry,
                    Type = categoryDto.Type,
                    Location = categoryDto.Location
                })
                .ToList();

            var tender = new Tender(
                command.Request.Title,
                command.Request.Description,
                command.Request.DateRange,
                command.Request.Budget,
                command.Request.EligibilityCriteria,
                TenderStatus.Draft,
                categories,
                command.UserId
            );

            await _tenderRepository.AddAsync(tender);

            return new TenderResponse
            {
                Id = tender.Id,
                Title = tender.Title,
                Description = tender.Description,
                DateRange = tender.DateRange,
                Budget = tender.Budget,
                EligibilityCriteria = tender.EligibilityCriteria,
                Status = tender.Status,
                Categories = command.Request.Categories
            };
        }
    }
}

