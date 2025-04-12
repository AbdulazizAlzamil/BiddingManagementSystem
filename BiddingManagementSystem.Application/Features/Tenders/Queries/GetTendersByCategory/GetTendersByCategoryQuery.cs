using MediatR;
using BiddingManagementSystem.Application.Contracts.Tenders;

namespace BiddingManagementSystem.Application.Features.Tenders.Queries.GetTendersByCategory
{
    public class GetTendersByCategoryQuery : IRequest<IEnumerable<TenderResponse>>
    {
        public string CategoryName { get; set; }

        public GetTendersByCategoryQuery(string categoryName)
        {
            CategoryName = categoryName;
        }
    }
}

