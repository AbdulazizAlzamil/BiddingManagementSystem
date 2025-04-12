using BiddingManagementSystem.Domain.Interfaces.Persistence;
using BiddingManagementSystem.Domain.Aggregates.TenderAggregate;
using Microsoft.EntityFrameworkCore;
using BiddingManagementSystem.Domain.Aggregates.EvaluationAggregate;

namespace BiddingManagementSystem.Infrastructure.Data.Persistence;

public class TenderRepository : ITenderRepository
{
    private readonly AppDbContext _context;

    public TenderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Tender tender)
    {
        await _context.Set<Tender>().AddAsync(tender);
        await _context.SaveChangesAsync();
    }

    public async Task<Tender> GetByIdAsync(int id)
    {
        return await _context.Tenders
            .Include(t => t.Categories)
            .Include(t => t.Bids)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task UpdateAsync(Tender tender)
    {
        _context.Set<Tender>().Update(tender);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Tender tender)
    {
        _context.Set<Tender>().Remove(tender);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Tender>> GetAllAsync()
    {
        return await _context.Set<Tender>().ToListAsync();
    }

    public async Task<IEnumerable<Tender>> GetTendersByCategoryAsync(string categoryName)
    {
        return await _context.Set<Tender>()
            .Where(t => t.Categories.Any(c => c.Name == categoryName))
            .ToListAsync();
    }

    public async Task<Tender> GetByBidIdAsync(int bidId)
    {
        return await _context.Set<Tender>()
            .Include(t => t.Bids)
            .ThenInclude(b => b.Documents)
            .FirstOrDefaultAsync(t => t.Bids.Any(b => b.Id == bidId));
    }

    public async Task<Tender> GetByDocumentIdAsync(int documentId)
    {
        return await _context.Tenders
            .Include(t => t.Documents)
            .FirstOrDefaultAsync(t => t.Documents.Any(d => d.Id == documentId));
    }

    public async Task<IEnumerable<Score>> GetScoresByTenderIdAsync(int tenderId)
    {
        return await _context.Scores
            .Where(score => score.Evaluation.Bid.TenderId == tenderId)
            .ToListAsync();
    }

    public async Task<IEnumerable<EvaluationCriteria>> GetEvaluationCriteriaAsync()
    {
        return await _context.EvaluationCriteria.ToListAsync();
    }
}


