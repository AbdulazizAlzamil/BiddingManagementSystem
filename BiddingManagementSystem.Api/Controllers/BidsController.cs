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
    /// <summary>
    /// Controller for managing bids in the bidding system.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = nameof(RoleType.Bidder))]
    public class BidsController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="BidsController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator instance for handling requests.</param>
        public BidsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Submits a new bid for a tender.
        /// </summary>
        /// <param name="command">The command containing bid details.</param>
        /// <returns>A success message if the bid is submitted successfully.</returns>
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitBid([FromBody] SubmitBidCommand command)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            command.UserId = userId;

            await _mediator.Send(command);
            return Ok("Bid submitted successfully.");
        }

        /// <summary>
        /// Retrieves all bids for a specific tender.
        /// </summary>
        /// <param name="tenderId">The ID of the tender.</param>
        /// <returns>A list of bids for the specified tender.</returns>
        [HttpGet("tenders/{tenderId}")]
        public async Task<IActionResult> GetBidsByTender(int tenderId)
        {
            var query = new GetBidsByTenderQuery { TenderId = tenderId };
            var bids = await _mediator.Send(query);
            return Ok(bids);
        }

        /// <summary>
        /// Uploads a document for a specific bid.
        /// </summary>
        /// <param name="bidId">The ID of the bid.</param>
        /// <param name="file">The file to upload.</param>
        /// <returns>A success message if the document is uploaded successfully.</returns>
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

        /// <summary>
        /// Deletes a specific bid.
        /// </summary>
        /// <param name="bidId">The ID of the bid to delete.</param>
        /// <returns>No content if the bid is deleted successfully, or an error message if not.</returns>
        [HttpDelete("{bidId}")]
        public async Task<IActionResult> DeleteBid(int bidId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _mediator.Send(new DeleteBidCommand(bidId, userId));

            if (!result)
                return NotFound("Bid not found or you do not have permission to delete it.");

            return NoContent();
        }

        /// <summary>
        /// Deletes a specific document associated with a bid.
        /// </summary>
        /// <param name="bidId">The ID of the bid.</param>
        /// <param name="documentId">The ID of the document to delete.</param>
        /// <returns>No content if the document is deleted successfully, or an error message if not.</returns>
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


