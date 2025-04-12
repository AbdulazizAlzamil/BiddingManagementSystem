namespace BiddingManagementSystem.Domain.ValueObjects
{
    public class ScoreValue
    {
        public int Value { get; private set; }

        public ScoreValue(int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Score must be between 0 and 100.");
            }
            Value = value;
        }
    }
}
