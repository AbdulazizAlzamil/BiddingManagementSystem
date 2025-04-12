namespace BiddingManagementSystem.Domain.Aggregates.TenderAggregate
{
    public class TenderCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Industry { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }

        public int TenderId { get; set; }
        public Tender Tender { get; set; }
    }
}
