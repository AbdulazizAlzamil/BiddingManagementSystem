using MediatR;

namespace BiddingManagementSystem.Application.Features.Tenders.Commands.PublishTender
{
    public class PublishTenderCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public PublishTenderCommand(int id)
        {
            Id = id;
        }
    }
}
