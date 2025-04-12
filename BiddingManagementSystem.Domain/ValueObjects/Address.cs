namespace BiddingManagementSystem.Domain.ValueObjects
{
    /// <summary>
    /// Represents a user's address.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// The street of the address (optional).
        /// </summary>
        public string? Street { get; set; }

        /// <summary>
        /// The city of the address (optional).
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// The state of the address (optional).
        /// </summary>
        public string? State { get; set; }

        /// <summary>
        /// The postal code of the address (optional).
        /// </summary>
        public string? PostalCode { get; set; }

        /// <summary>
        /// The country of the address (optional).
        /// </summary>
        public string? Country { get; set; }

        public Address() { }

        public Address(string? street, string? city, string? state, string? postalCode, string? country)
        {
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
            Country = country;
        }
    }
}
