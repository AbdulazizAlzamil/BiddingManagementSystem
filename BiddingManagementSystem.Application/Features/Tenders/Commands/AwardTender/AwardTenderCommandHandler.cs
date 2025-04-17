using BiddingManagementSystem.Domain.Enums;
using BiddingManagementSystem.Domain.Interfaces.Persistence;
using BiddingManagementSystem.Application.Interfaces;
using MediatR;

namespace BiddingManagementSystem.Application.Features.Tenders.Commands.AwardTender;

public class AwardTenderCommandHandler : IRequestHandler<AwardTenderCommand, bool>
{
    private readonly ITenderRepository _tenderRepository;
    private readonly IEmailService _emailService;

    public AwardTenderCommandHandler(ITenderRepository tenderRepository, IEmailService emailService)
    {
        _tenderRepository = tenderRepository;
        _emailService = emailService;
    }

    public async Task<bool> Handle(AwardTenderCommand command, CancellationToken cancellationToken)
    {
        // Retrieve the tender
        var tender = await _tenderRepository.GetByIdAsync(command.TenderId);
        if (tender == null)
            throw new InvalidOperationException("Tender not found.");

        if (tender.Status != TenderStatus.Published)
            throw new InvalidOperationException("Tender is not in a valid state to be awarded.");

        // Validate the winning bid
        var winningBid = tender.Bids.FirstOrDefault(b => b.Id == command.WinningBidId);
        if (winningBid == null)
            throw new InvalidOperationException($"Bid with ID {command.WinningBidId} not found in the tender.");

        if (winningBid.Evaluation == null || winningBid.Evaluation.TotalScore <= 0)
            throw new InvalidOperationException($"Bid with ID {command.WinningBidId} does not have a valid evaluation or score.");

        // Set the winning bid
        tender.SetWinningBid(winningBid);

        // Update the tender in the repository
        await _tenderRepository.UpdateAsync(tender);

        // Notify bidders
        var bidderEmails = tender.Bids.Select(b => b.User.Email).Distinct();
        await _emailService.SendBulkEmailAsync(
            bidderEmails,
            "Tender Awarded",
            $"The tender '{tender.Title}' has been awarded. Please check the details."
        );

        return true;
    }
}
