using MediatR;

namespace BiddingManagementSystem.Application.Features.Tenders.Commands.DeleteTender
{
    public class DeleteTenderCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public DeleteTenderCommand(int id, int userId)
        {
            Id = id;
            UserId = userId;
        }
    }
}
