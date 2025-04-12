using BiddingManagementSystem.Domain.ValueObjects;

namespace BiddingManagementSystem.Domain.Aggregates.EvaluationAggregate
{
    public class Score
    {
        public int Id { get; set; }
        public int EvaluationCriteriaId { get; set; }
        public int EvaluationId { get; set; }
        public ScoreValue Value { get; set; }

        public EvaluationCriteria EvaluationCriteria { get; set; }
        public Evaluation Evaluation { get; set; }
    }
}
