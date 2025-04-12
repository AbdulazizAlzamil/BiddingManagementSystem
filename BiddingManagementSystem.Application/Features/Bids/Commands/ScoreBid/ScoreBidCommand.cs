using MediatR;

namespace BiddingManagementSystem.Application.Features.Bids.Commands.ScoreBid;

public class ScoreBidCommand : IRequest<bool>
{
    public int TenderId { get; set; }
    public int BidId { get; set; }
    public string Comments { get; set; }
    public IDictionary<int, int> Scores { get; set; }
}

