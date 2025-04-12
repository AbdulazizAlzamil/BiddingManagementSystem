using BiddingManagementSystem.Application.Interfaces;
using BiddingManagementSystem.Domain.Aggregates.TenderAggregate;
using BiddingManagementSystem.Domain.Enums;
using BiddingManagementSystem.Domain.Interfaces.Persistence;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace BiddingManagementSystem.Application.Services
{
    public class BidService : IBidService
    {
        private readonly ITenderRepository _tenderRepository;
        private readonly IFileStorageService _fileStorageService;

        public BidService(ITenderRepository tenderRepository, IFileStorageService fileStorageService)
        {
            _tenderRepository = tenderRepository;
            _fileStorageService = fileStorageService;
        }

        public async Task SubmitBidAsync(int tenderId, int userId, decimal amount)
        {
            var tender = await _tenderRepository.GetByIdAsync(tenderId);
            if (tender == null) throw new ArgumentException("Tender not found.");

            var bid = Bid.Create(tenderId, userId, amount, BidStatus.Submitted);
            tender.AddBid(bid);

            await _tenderRepository.UpdateAsync(tender);
        }

        public async Task<IEnumerable<Bid>> GetBidsByTenderAsync(int tenderId)
        {
            var tender = await _tenderRepository.GetByIdAsync(tenderId);
            if (tender == null) throw new ArgumentException("Tender not found.");
            return tender.Bids;
        }

        public async Task<bool> UploadBidDocumentAsync(int bidId, string filePath)
        {
            var tender = await _tenderRepository.GetByBidIdAsync(bidId);
            var bid = tender?.Bids.FirstOrDefault(b => b.Id == bidId);
            if (bid == null) throw new ArgumentException("Bid not found.");

            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("Invalid file path.");

            var document = new BidDocument
            {
                BidId = bidId,
                FilePath = filePath
            };

            bid.AttachDocument(document);
            await _tenderRepository.UpdateAsync(tender);

            return true;
        }
    }
}
