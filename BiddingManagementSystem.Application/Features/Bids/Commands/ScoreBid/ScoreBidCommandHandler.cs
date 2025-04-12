using BiddingManagementSystem.Domain.Aggregates.EvaluationAggregate;
using BiddingManagementSystem.Domain.Enums;
using BiddingManagementSystem.Domain.Interfaces.Persistence;
using BiddingManagementSystem.Domain.ValueObjects;
using MediatR;

namespace BiddingManagementSystem.Application.Features.Bids.Commands.ScoreBid;

public class ScoreBidCommandHandler : IRequestHandler<ScoreBidCommand, bool>
{
    private readonly ITenderRepository _tenderRepository;

    public ScoreBidCommandHandler(ITenderRepository tenderRepository)
    {
        _tenderRepository = tenderRepository;
    }

    public async Task<bool> Handle(ScoreBidCommand command, CancellationToken cancellationToken)
    {
        // Retrieve the tender
        var tender = await _tenderRepository.GetByIdAsync(command.TenderId);
        if(tender == null || tender.Status != TenderStatus.Published)
            throw new InvalidOperationException("Tender not found or not in a valid state.");

        // Retrieve all evaluation criteria
        var criteria = await _tenderRepository.GetEvaluationCriteriaAsync();
        if(criteria == null || !criteria.Any())
            throw new InvalidOperationException("No evaluation criteria found.");

        // Retrieve the bid
        var bid = tender.Bids.FirstOrDefault(b => b.Id == command.BidId);
        if(bid == null)
            throw new InvalidOperationException("Bid not found.");

        // Retrieve or create the evaluation for the bid
        var evaluation = bid.Evaluation ?? new Evaluation(bid.Id, command.Comments, 0);

        // Iterate over the Scores dictionary and update/add scores
        foreach(var scoreEntry in command.Scores)
        {
            var evaluationCriteriaId = scoreEntry.Key;
            var scoreValue = scoreEntry.Value;

            // Validate that the criteria exists
            if(!criteria.Any(c => c.Id == evaluationCriteriaId))
                throw new InvalidOperationException($"Invalid EvaluationCriteriaId: {evaluationCriteriaId}");

            // Add or update the score for the evaluation
            var score = evaluation.Scores.FirstOrDefault(s => s.EvaluationCriteriaId == evaluationCriteriaId);
            if(score == null)
            {
                score = new Score
                {
                    EvaluationCriteriaId = evaluationCriteriaId,
                    Value = new ScoreValue(scoreValue)
                };
                evaluation.AddScore(score);
            }
            else
            {
                score.Value = new ScoreValue(scoreValue);
            }
        }

        evaluation.CalculateTotalScore();

        if(bid.Evaluation == null)
        {
            bid.AddEvaluation(evaluation);
        }

        await _tenderRepository.UpdateAsync(tender);

        return true;
    }
}
