using BiddingManagementSystem.Application.Contracts.Tenders;
using BiddingManagementSystem.Domain.Aggregates.TenderAggregate;
using BiddingManagementSystem.Domain.Enums;
using BiddingManagementSystem.Domain.Interfaces.Persistence;
using MediatR;

namespace BiddingManagementSystem.Application.Features.Tenders.Queries.GetOpenTenders
{
    public class GetOpenTendersQueryHandler : IRequestHandler<GetOpenTendersQuery, IEnumerable<TenderResponse>>
    {
        private readonly ITenderRepository _tenderRepository;

        public GetOpenTendersQueryHandler(ITenderRepository tenderRepository)
        {
            _tenderRepository = tenderRepository;
        }

        public async Task<IEnumerable<TenderResponse>> Handle(GetOpenTendersQuery query, CancellationToken cancellationToken)
        {
            var tenders = await _tenderRepository.GetAllAsync();
            var openTenders = tenders.Where(t => t.Status == TenderStatus.Published);

            return openTenders.Select(t => new TenderResponse
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DateRange = t.DateRange,
                Budget = t.Budget,
                EligibilityCriteria = t.EligibilityCriteria,
                Status = t.Status,
                Categories = 
                    t.Categories.Select(c => new TenderCategoryDto { Name = c.Name, Industry = c.Industry, Type = c.Type, Location = c.Location }).ToList()
            });
        }
    }
}

