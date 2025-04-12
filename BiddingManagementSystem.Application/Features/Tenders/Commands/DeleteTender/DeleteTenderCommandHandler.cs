using BiddingManagementSystem.Domain.Interfaces.Persistence;
using MediatR;

namespace BiddingManagementSystem.Application.Features.Tenders.Commands.DeleteTender
{
    public class DeleteTenderCommandHandler : IRequestHandler<DeleteTenderCommand, bool>
    {
        private readonly ITenderRepository _tenderRepository;

        public DeleteTenderCommandHandler(ITenderRepository tenderRepository)
        {
            _tenderRepository = tenderRepository;
        }

        public async Task<bool> Handle(DeleteTenderCommand command, CancellationToken cancellationToken)
        {
            var tender = await _tenderRepository.GetByIdAsync(command.Id);
            if (tender == null || tender.UserId != command.UserId) // Validate ownership
                return false;

            await _tenderRepository.DeleteAsync(tender);
            return true;
        }
    }
}

