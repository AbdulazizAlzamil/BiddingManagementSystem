namespace BiddingManagementSystem.Domain.ValueObjects
{
    /// <summary>
    /// Represents a range of dates.
    /// </summary>
    public class DateTimeRange
    {
        /// <summary>
        /// Start date of the range.
        /// Example: "2023-01-01T00:00:00".
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// End date of the range.
        /// Example: "2023-12-31T23:59:59".
        /// </summary>
        public DateTime End { get; set; }

        public DateTimeRange(DateTime start, DateTime end)
        {
            if(end < start)
            {
                throw new ArgumentException("End date must be greater than or equal to start date.");
            }
            Start = start;
            End = end;
        }

        // Add a parameterless constructor
        public DateTimeRange() { }

        // Add other properties and methods as needed
    }
}
