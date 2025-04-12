using MediatR;
using Microsoft.AspNetCore.Http;

namespace BiddingManagementSystem.Application.Features.Tenders.Commands.UploadTenderDocument
{
    public class UploadTenderDocumentCommand : IRequest<bool>
    {
        public int TenderId { get; set; }
        public IFormFile File { get; set; }

        public UploadTenderDocumentCommand(int tenderId, IFormFile file)
        {
            TenderId = tenderId;
            File = file;
        }
    }
}

