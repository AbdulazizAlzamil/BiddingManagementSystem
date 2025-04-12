namespace BiddingManagementSystem.Domain.Aggregates.EvaluationAggregate
{
    public class EvaluationCriteria
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Score> Scores { get; set; }

        public EvaluationCriteria()
        {
            Scores = new List<Score>();
        }
    }
}
