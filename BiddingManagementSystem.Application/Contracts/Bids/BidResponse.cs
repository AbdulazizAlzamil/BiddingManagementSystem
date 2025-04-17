using BiddingManagementSystem.Domain.Enums;

namespace BiddingManagementSystem.Application.Contracts.Bids
{
    public class BidResponse
    {
        public int TenderId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime BidDate { get; set; }
        public string Status { get; set; }
    }
}

