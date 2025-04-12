using BiddingManagementSystem.Domain.ValueObjects;
using BiddingManagementSystem.Domain.Enums;
using BiddingManagementSystem.Domain.Aggregates.UserAggregate;

namespace BiddingManagementSystem.Domain.Aggregates.TenderAggregate
{
    public class Tender
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTimeRange DateRange { get; private set; }
        public Money Budget { get; private set; }
        public string EligibilityCriteria { get; private set; }
        public TenderStatus Status { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public ICollection<Bid> Bids { get; private set; }
        public ICollection<TenderDocument> Documents { get; private set; }
        public ICollection<TenderCategory> Categories { get; private set; }
        public int? WinningBidId { get; private set; }
        public Bid WinningBid { get; private set; }

        public Tender()
        {
            Bids = new List<Bid>();
            Documents = new List<TenderDocument>();
            Categories = new List<TenderCategory>();
        }

        public Tender(
            string title,
            string description,
            DateTimeRange dateRange,
            Money budget,
            string eligibilityCriteria,
            TenderStatus status,
            ICollection<TenderCategory> categories,
            int userId)
        {
            Title = title;
            Description = description;
            DateRange = dateRange;
            Budget = budget;
            EligibilityCriteria = eligibilityCriteria;
            Status = status;
            Categories = categories ?? new List<TenderCategory>();
            UserId = userId;
            Bids = new List<Bid>();
            Documents = new List<TenderDocument>();
        }

        public void UpdateDetails(string title, string description, DateTimeRange dateRange, Money budget, string eligibilityCriteria, TenderStatus status, ICollection<TenderCategory> categories)
        {
            Title = title;
            Description = description;
            DateRange = dateRange;
            Budget = budget;
            EligibilityCriteria = eligibilityCriteria;
            Status = status;
            Categories = categories ?? new List<TenderCategory>();
        }

        public void AddBid(Bid bid)
        {
            if (!bid.ValidateBid(this))
                throw new InvalidOperationException("Bid does not meet the tender's requirements.");

            Bids.Add(bid);
        }

        public void RemoveBid(Bid bid)
        {
            Bids.Remove(bid);
        }

        public void AddDocument(TenderDocument document)
        {
            if (Documents == null)
            {
                Documents = new List<TenderDocument>();
            }
            Documents.Add(document);
        }

        public void RemoveDocument(TenderDocument document)
        {
            Documents.Remove(document);
        }

        public void AddCategory(TenderCategory category)
        {
            category.TenderId = Id;
            Categories.Add(category);
        }

        public void RemoveCategory(TenderCategory category)
        {
            Categories.Remove(category);
        }

        public void SetWinningBid(Bid winningBid)
        {
            if (Status != TenderStatus.Published)
                throw new InvalidOperationException("Tender must be published to award.");

            WinningBidId = winningBid.Id;
            WinningBid = winningBid;
            Status = TenderStatus.Awarded;
        }
    }
}
