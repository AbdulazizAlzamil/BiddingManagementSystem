using BiddingManagementSystem.Domain.Enums;
using BiddingManagementSystem.Domain.ValueObjects;

namespace BiddingManagementSystem.Application.Contracts.Tenders;

/// <summary>
/// Represents the request to update a tender.
/// </summary>
public class UpdateTenderRequest
{
    /// <summary>
    /// Updated title of the tender.
    /// Example: "Renovation of the existing office building".
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Updated description of the tender.
    /// Example: "This tender is for the renovation of the existing office building".
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Updated date range for the tender.
    /// Example: { "start": "2023-06-01T00:00:00", "end": "2023-12-31T23:59:59" }.
    /// </summary>
    public DateTimeRange DateRange { get; set; }

    /// <summary>
    /// Updated budget for the tender.
    /// Example: { "amount": 500000.00, "currency": "USD" }.
    /// </summary>
    public Money Budget { get; set; }

    /// <summary>
    /// Updated eligibility criteria for the tender.
    /// Example: "Must have at least 3 years of experience in renovation".
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
