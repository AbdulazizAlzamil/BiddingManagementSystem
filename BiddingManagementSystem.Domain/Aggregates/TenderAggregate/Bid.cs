using BiddingManagementSystem.Domain.Aggregates.EvaluationAggregate;
using BiddingManagementSystem.Domain.Aggregates.UserAggregate;
using BiddingManagementSystem.Domain.Enums;

namespace BiddingManagementSystem.Domain.Aggregates.TenderAggregate
{
    public class Bid
    {
        public int Id { get; private set; }
        public int TenderId { get; private set; }
        public int UserId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime BidDate { get; private set; }
        public BidStatus Status { get; private set; }
        
        [System.Text.Json.Serialization.JsonIgnore]
        public Tender Tender { get; private set; }
        
        public User User { get; private set; }
        public Evaluation Evaluation { get; private set; }
        public ICollection<BidDocument> Documents { get; private set; }

        public Bid()
        {
            Documents = new List<BidDocument>();
        }

        public Bid(int tenderId, int userId, decimal amount, DateTime bidDate, BidStatus status)
        {
            TenderId = tenderId;
            UserId = userId;
            Amount = amount;
            BidDate = bidDate;
            Status = status;
            Documents = new List<BidDocument>();
        }

        public static Bid Create(int tenderId, int userId, decimal amount, BidStatus status)
        {
            if(amount <= 0) throw new ArgumentException("Bid amount must be greater than zero.");
            if(tenderId <= 0) throw new ArgumentException("Tender ID is required.");
            if(userId <= 0) throw new ArgumentException("User ID is required.");

            return new Bid(tenderId, userId, amount, DateTime.UtcNow, status);
        }

        public void UpdateAmount(decimal newAmount)
        {
            Amount = newAmount;
        }

        public void UpdateStatus(BidStatus newStatus)
        {
            Status = newStatus;
        }

        public void AttachDocument(BidDocument document)
        {
            if(document == null || string.IsNullOrEmpty(document.FilePath))
                throw new ArgumentException("Invalid document.");

            Documents.Add(document);
        }

        public void AddEvaluation(Evaluation evaluation)
        {
            if(evaluation == null)
                throw new ArgumentException("Invalid evaluation.");
            Evaluation = evaluation;
        }

        public bool ValidateBid(Tender tender)
        {
            if(Amount > tender.Budget.Amount)
                return false;

            if(tender.DateRange.End < DateTime.Now)
                return false;

            return true;
        }
    }
}
