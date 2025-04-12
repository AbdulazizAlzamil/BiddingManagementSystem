namespace BiddingManagementSystem.Domain.Aggregates.TenderAggregate
{
    public class TenderDocument
    {
        public int Id { get; set; }
        public int TenderId { get; set; }
        public string FilePath { get; set; }

        public Tender Tender { get; set; }
    }
}
