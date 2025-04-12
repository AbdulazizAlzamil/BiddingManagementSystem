using BiddingManagementSystem.Application.Contracts.Tenders;
using Microsoft.AspNetCore.Http;

namespace BiddingManagementSystem.Application.Interfaces
{
    public interface ITenderService
    {
        Task<TenderResponse> CreateTenderAsync(CreateTenderRequest request);
        Task<TenderResponse> GetTenderByIdAsync(int id);
        Task<bool> UpdateTenderAsync(int id, UpdateTenderRequest request);
        Task<bool> DeleteTenderAsync(int id);
        Task<bool> UploadTenderDocumentAsync(int tenderId, string filePath);
    }
}
