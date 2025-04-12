namespace BiddingManagementSystem.Domain.Aggregates.TenderAggregate
{
    public class BidDocument
    {
        public int Id { get; set; }
        public int BidId { get; set; }
        public string FilePath { get; set; }

        public Bid Bid { get; set; }
    }
}


