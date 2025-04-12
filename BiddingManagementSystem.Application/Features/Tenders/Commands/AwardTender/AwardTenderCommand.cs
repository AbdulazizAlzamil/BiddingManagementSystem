using MediatR;

public class AwardTenderCommand : IRequest<bool>
{
    public int TenderId { get; set; }
    public int WinningBidId { get; set; }
}