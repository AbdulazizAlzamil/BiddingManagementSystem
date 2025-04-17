using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BiddingManagementSystem.Application.Features.Bids.Commands.SubmitBid;
using BiddingManagementSystem.Application.Features.Bids.Queries.GetBidsByTender;
using BiddingManagementSystem.Application.Features.Bids.Commands.UploadBidDocument;
using BiddingManagementSystem.Application.Features.Bids.Commands.DeleteBid;
using BiddingManagementSystem.Application.Features.Bids.Commands.DeleteBidDocument;
using BiddingManagementSystem.Domain.Enums;

namespace BiddingManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = nameof(RoleType.Bidder))]
    public class BidsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BidsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitBid([FromBody] SubmitBidCommand command)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            command.UserId = userId;

            await _mediator.Send(command);
            return Ok("Bid submitted successfully.");
        }

        [HttpGet("tenders/{tenderId}")]
        public async Task<IActionResult> GetBidsByTender(int tenderId)
        {
            var query = new GetBidsByTenderQuery { TenderId = tenderId };
            var bids = await _mediator.Send(query);
            return Ok(bids);
        }

        [HttpPost("{bidId}/upload-document")]
        public async Task<IActionResult> UploadBidDocument(int bidId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Invalid file.");

            var command = new UploadBidDocumentCommand(bidId, file);
            var result = await _mediator.Send(command);

            if (!result)
                return StatusCode(500, "Failed to upload document.");

            return Ok("Document uploaded successfully.");
        }

        [HttpDelete("{bidId}")]
        public async Task<IActionResult> DeleteBid(int bidId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _mediator.Send(new DeleteBidCommand(bidId, userId));

            if (!result)
                return NotFound("Bid not found or you do not have permission to delete it.");

            return NoContent();
        }

        [HttpDelete("{bidId}/documents/{documentId}")]
        public async Task<IActionResult> DeleteBidDocument(int bidId, int documentId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _mediator.Send(new DeleteBidDocumentCommand(bidId, documentId, userId));

            if (!result)
                return NotFound("Document not found or you do not have permission to delete it.");

            return NoContent();
        }
    }
}


