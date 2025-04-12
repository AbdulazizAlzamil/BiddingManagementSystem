using BiddingManagementSystem.Domain.Enums;
using BiddingManagementSystem.Domain.ValueObjects;

namespace BiddingManagementSystem.Application.Contracts.Tenders
{
    public class TenderResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeRange DateRange { get; set; }
        public Money Budget { get; set; }
        public string EligibilityCriteria { get; set; }
        public TenderStatus Status { get; set; }
        public ICollection<TenderCategoryDto> Categories { get; set; }
    }
}

