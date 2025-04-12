using MediatR;
using System.Text.Json.Serialization;

namespace BiddingManagementSystem.Application.Features.Bids.Commands.SubmitBid
{
    public class SubmitBidCommand : IRequest<Unit>
    {
        public int TenderId { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        public decimal Amount { get; set; }
    }
}

