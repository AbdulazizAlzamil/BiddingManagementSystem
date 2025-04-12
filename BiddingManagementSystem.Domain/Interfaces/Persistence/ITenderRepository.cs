using BiddingManagementSystem.Domain.Aggregates.EvaluationAggregate;
using BiddingManagementSystem.Domain.Aggregates.TenderAggregate;

namespace BiddingManagementSystem.Domain.Interfaces.Persistence
{
    public interface ITenderRepository
    {
        Task AddAsync(Tender tender);
        Task<Tender> GetByIdAsync(int id);
        Task UpdateAsync(Tender tender);
        Task DeleteAsync(Tender tender);
        Task<IEnumerable<Tender>> GetAllAsync();
        Task<IEnumerable<Tender>> GetTendersByCategoryAsync(string categoryName);
        Task<Tender> GetByBidIdAsync(int bidId);
        Task<Tender> GetByDocumentIdAsync(int documentId);
        Task<IEnumerable<Score>> GetScoresByTenderIdAsync(int tenderId);
        Task<IEnumerable<EvaluationCriteria>> GetEvaluationCriteriaAsync();
        //Task NotifyBiddersAsync(int tenderId, string message);
    }
}
