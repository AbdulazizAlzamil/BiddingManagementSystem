namespace BiddingManagementSystem.Domain.ValueObjects
{
    /// <summary>
    /// Represents a monetary value.
    /// </summary>
    public class Money
    {
        /// <summary>
        /// Amount of money.
        /// Example: 1000000.00.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Currency of the money.
        /// Example: "USD".
        /// </summary>
        public string Currency { get; set; }

        public Money(decimal amount, string currency)
        {
            if(amount < 0)
            {
                throw new ArgumentException("Amount must be greater than or equal to zero.");
            }
            Amount = amount;
            Currency = currency;
        }

        public Money() { }
    }
}
