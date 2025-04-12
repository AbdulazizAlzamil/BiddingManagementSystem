using BiddingManagementSystem.Application.Contracts.Tenders;
using BiddingManagementSystem.Application.Features.Tenders.Queries;
using BiddingManagementSystem.Domain.Interfaces.Persistence;
using MediatR;

public class GetTenderByIdQueryHandler : IRequestHandler<GetTenderByIdQuery, TenderResponse>
{
    private readonly ITenderRepository _tenderRepository;

    public GetTenderByIdQueryHandler(ITenderRepository tenderRepository)
    {
        _tenderRepository = tenderRepository;
    }

    public async Task<TenderResponse> Handle(GetTenderByIdQuery query, CancellationToken cancellationToken)
    {
        var tender = await _tenderRepository.GetByIdAsync(query.Id);
        if (tender == null) return null;

        return new TenderResponse
        {
            Id = tender.Id,
            Title = tender.Title,
            Description = tender.Description,
            DateRange = tender.DateRange,
            Budget = tender.Budget,
            EligibilityCriteria = tender.EligibilityCriteria,
            Status = tender.Status,
            Categories = tender.Categories?.Select(c => new TenderCategoryDto 
            { 
                Id = c.Id,
                Name = c.Name, 
                Industry = c.Industry, 
                Type = c.Type, 
                Location = c.Location 
            }).ToList()
        };
    }
}