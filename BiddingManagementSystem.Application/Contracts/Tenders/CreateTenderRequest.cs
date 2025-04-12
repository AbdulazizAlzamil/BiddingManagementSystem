using BiddingManagementSystem.Domain.Enums;
using BiddingManagementSystem.Domain.ValueObjects;

namespace BiddingManagementSystem.Application.Contracts.Tenders;

/// <summary>
/// Represents the request to create a tender.
/// </summary>
public class CreateTenderRequest
{
    /// <summary>
    /// Identifier of the user creating the tender.
    /// Example: "2".
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Title of the tender.
    /// Example: "Construction of a new office building".
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Description of the tender.
    /// Example: "This tender is for the construction of a new office building in downtown".
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Date range for the tender.
    /// Example: { "start": "2023-01-01T00:00:00", "end": "2023-12-31T23:59:59" }.
    /// </summary>
    public DateTimeRange DateRange { get; set; }

    /// <summary>
    /// Budget for the tender.
    /// Example: { "amount": 1000000.00, "currency": "USD" }.
    /// </summary>
    public Money Budget { get; set; }

    /// <summary>
    /// Eligibility criteria for the tender.
    /// Example: "Must have at least 5 years of experience in construction".
    /// </summary>
    public string EligibilityCriteria { get; set; }

    /// <summary>
    /// Status of the tender.
    /// Example: 0 (Active).
    /// </summary>
    public TenderStatus Status { get; set; }

    /// <summary>
    /// Categories associated with the tender.
    /// Example: ["Construction", "Office Building"].
    /// </summary>
    public ICollection<TenderCategoryDto> Categories { get; set; }
}

