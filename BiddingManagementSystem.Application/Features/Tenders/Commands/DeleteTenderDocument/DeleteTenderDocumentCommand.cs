using MediatR;

namespace BiddingManagementSystem.Application.Features.Tenders.Commands.DeleteTenderDocument
{
    public class DeleteTenderDocumentCommand : IRequest<bool>
    {
        public int DocumentId { get; set; }
        public int UserId { get; set; }

        public DeleteTenderDocumentCommand(int documentId, int userId)
        {
            DocumentId = documentId;
            UserId = userId;
        }
    }
}
