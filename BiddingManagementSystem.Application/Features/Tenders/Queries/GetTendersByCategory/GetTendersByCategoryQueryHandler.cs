using BiddingManagementSystem.Application.Contracts.Tenders;
using BiddingManagementSystem.Domain.Interfaces.Persistence;
using MediatR;

namespace BiddingManagementSystem.Application.Features.Tenders.Queries.GetTendersByCategory
{
    public class GetTendersByCategoryQueryHandler : IRequestHandler<GetTendersByCategoryQuery, IEnumerable<TenderResponse>>
    {
        private readonly ITenderRepository _tenderRepository;

        public GetTendersByCategoryQueryHandler(ITenderRepository tenderRepository)
        {
            _tenderRepository = tenderRepository;
        }

        public async Task<IEnumerable<TenderResponse>> Handle(GetTendersByCategoryQuery request, CancellationToken cancellationToken)
        {
            var tenders = await _tenderRepository.GetTendersByCategoryAsync(request.CategoryName);

            return tenders.Select(t => new TenderResponse
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DateRange = t.DateRange,
                Budget = t.Budget,
                EligibilityCriteria = t.EligibilityCriteria,
                Status = t.Status,
                Categories = t.Categories.Select(c => new TenderCategoryDto
                {
                    Name = c.Name,
                    Industry = c.Industry,
                    Type = c.Type,
                    Location = c.Location
                }).ToList()
            }).ToList();
        }
    }
}

