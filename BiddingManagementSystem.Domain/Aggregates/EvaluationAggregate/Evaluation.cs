using BiddingManagementSystem.Domain.Aggregates.TenderAggregate;
using BiddingManagementSystem.Domain.Enums;
using BiddingManagementSystem.Domain.ValueObjects;

namespace BiddingManagementSystem.Domain.Aggregates.EvaluationAggregate
{
    public class Evaluation
    {
        public int Id { get; private set; }
        public string Comments { get; private set; }
        public int TotalScore { get; private set; }
        public int BidId { get; private set; }
        public Bid Bid { get; private set; }

        public ICollection<Score> Scores { get; set; }

        public Evaluation()
        {
            Scores = new List<Score>();
        }

        public Evaluation(int bidId, string comments, int totalScore)
        {
            BidId = bidId;
            Comments = comments;
            TotalScore = totalScore;
            Scores = new List<Score>();
        }

        public void UpdateComments(string newComments)
        {
            Comments = newComments;
        }

        public void UpdateTotalScore(int newTotalScore)
        {
            TotalScore = newTotalScore;
        }

        public void AddScore(Score score)
        {
            if(Scores.Any(s => s.EvaluationCriteriaId == score.EvaluationCriteriaId)) return;
            Scores.Add(score);
        }

        public void CalculateTotalScore()
        {
            TotalScore = Scores?.Sum(s => s.Value.Value) ?? 0;
        }
    }
}
