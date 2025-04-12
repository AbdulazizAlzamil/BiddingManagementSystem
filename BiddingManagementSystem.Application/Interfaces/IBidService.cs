using BiddingManagementSystem.Domain.Aggregates.TenderAggregate;
using Microsoft.AspNetCore.Http;

namespace BiddingManagementSystem.Application.Interfaces
{
    public interface IBidService
    {
        Task SubmitBidAsync(int tenderId, int userId, decimal amount);
        Task<IEnumerable<Bid>> GetBidsByTenderAsync(int tenderId);
        Task<bool> UploadBidDocumentAsync(int bidId, string filePath);
    }
}
