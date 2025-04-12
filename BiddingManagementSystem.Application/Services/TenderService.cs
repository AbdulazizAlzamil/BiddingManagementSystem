using BiddingManagementSystem.Application.Contracts.Tenders;
using BiddingManagementSystem.Application.Interfaces;
using BiddingManagementSystem.Domain.Aggregates.TenderAggregate;
using BiddingManagementSystem.Domain.Enums;
using BiddingManagementSystem.Domain.Interfaces.Persistence;

namespace BiddingManagementSystem.Application.Services
{
    public class TenderService : ITenderService
    {
        private readonly ITenderRepository _tenderRepository;
        private readonly IFileStorageService _fileStorageService;

        public TenderService(ITenderRepository tenderRepository, IFileStorageService fileStorageService)
        {
            _tenderRepository = tenderRepository;
            _fileStorageService = fileStorageService;
        }

        public async Task<TenderResponse> CreateTenderAsync(CreateTenderRequest request)
        {
            var tender = new Tender(
                request.Title,
                request.Description,
                request.DateRange,
                request.Budget,
                request.EligibilityCriteria,
                TenderStatus.Draft,
                request.Categories.Select(c => new TenderCategory { Name = c.Name, Industry = c.Industry, Type = c.Type, Location = c.Location }).ToList(),
                request.UserId
            );

            await _tenderRepository.AddAsync(tender);

            return new TenderResponse
            {
                Id = tender.Id,
                Title = tender.Title,
                Description = tender.Description,
                DateRange = tender.DateRange,
                Budget = tender.Budget,
                EligibilityCriteria = tender.EligibilityCriteria,
                Status = tender.Status,
                Categories = tender.Categories.Select(c => new TenderCategoryDto { Name = c.Name, Industry = c.Industry, Type = c.Type, Location = c.Location }).ToList()
            };
        }


        public async Task<TenderResponse> GetTenderByIdAsync(int id)
        {
            var tender = await _tenderRepository.GetByIdAsync(id);
            if (tender == null) return null;

            return new TenderResponse
            {
                Id = tender.Id,
                Title = tender.Title,
                Description = tender.Description,
                DateRange = tender.DateRange,
                Budget = tender.Budget,
                EligibilityCriteria = tender.EligibilityCriteria,
                Status = tender.Status,
                Categories = tender.Categories.Select(c => new TenderCategoryDto { Name = c.Name, Industry = c.Industry, Type = c.Type, Location = c.Location }).ToList()   
            };
        }

        public async Task<bool> UpdateTenderAsync(int id, UpdateTenderRequest request)
        {
            var tender = await _tenderRepository.GetByIdAsync(id);
            if (tender == null) return false;

            tender.UpdateDetails(
                request.Title,
                request.Description,
                request.DateRange,
                request.Budget,
                request.EligibilityCriteria,
                TenderStatus.Draft,
                request.Categories.Select(c => new TenderCategory { Name = c.Name, Industry = c.Industry, Type = c.Type, Location = c.Location }).ToList()
            );

            await _tenderRepository.UpdateAsync(tender);
            return true;
        }

        public async Task<bool> DeleteTenderAsync(int id)
        {
            var tender = await _tenderRepository.GetByIdAsync(id);
            if (tender == null) return false;

            await _tenderRepository.DeleteAsync(tender);
            return true;
        }

        public async Task<bool> UploadTenderDocumentAsync(int tenderId, string filePath)
        {
            var tender = await _tenderRepository.GetByIdAsync(tenderId);
            if (tender == null) return false;

            var document = new TenderDocument
            {
                TenderId = tenderId,
                FilePath = filePath
            };

            tender.AddDocument(document);
            await _tenderRepository.UpdateAsync(tender);

            return true;
        }
    }
}
