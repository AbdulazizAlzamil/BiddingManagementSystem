using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BiddingManagementSystem.Domain.Enums;
using BiddingManagementSystem.Application.Contracts.Tenders;
using MediatR;
using System.Security.Claims;
using BiddingManagementSystem.Application.Features.Tenders.Commands;
using BiddingManagementSystem.Application.Features.Tenders.Queries;
using BiddingManagementSystem.Application.Features.Tenders.Commands.DeleteTender;
using BiddingManagementSystem.Application.Features.Tenders.Commands.UploadTenderDocument;
using BiddingManagementSystem.Application.Features.Tenders.Commands.DeleteTenderDocument;
using BiddingManagementSystem.Application.Features.Bids.Commands.ScoreBid;
using BiddingManagementSystem.Application.Features.Tenders.Commands.PublishTender;

namespace BiddingManagementSystem.Api.Controllers
{
    /// <summary>
    /// Controller for managing tenders.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = nameof(RoleType.ProcurementOfficer))]
    public class TendersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TendersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new tender.
        /// </summary>
        /// <param name="request">The request containing tender details.</param>
        /// <returns>The created tender.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateTender([FromBody] CreateTenderRequest request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _mediator.Send(new CreateTenderCommand(request, userId));
            return CreatedAtAction(nameof(GetTenderById), new { id = result.Id }, result);
        }

        /// <summary>
        /// Retrieves a tender by its ID.
        /// </summary>
        /// <param name="id">The ID of the tender.</param>
        /// <returns>The tender details.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTenderById(int id)
        {
            var result = await _mediator.Send(new GetTenderByIdQuery(id));
            if (result == null) return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Updates an existing tender.
        /// </summary>
        /// <param name="id">The ID of the tender to update.</param>
        /// <param name="request">The updated tender details.</param>
        /// <returns>No content if successful.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTender(int id, [FromBody] UpdateTenderRequest request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _mediator.Send(new UpdateTenderCommand(id, request, userId));
            if (!result) return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Deletes a tender by its ID.
        /// </summary>
        /// <param name="id">The ID of the tender to delete.</param>
        /// <returns>No content if successful.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTender(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _mediator.Send(new DeleteTenderCommand(id, userId));
            if (!result) return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Publishes a tender, changing its status to Published.
        /// </summary>
        /// <param name="tenderId">The ID of the tender to publish.</param>
        /// <returns>Ok if successful, NotFound if the tender does not exist.</returns>
        [HttpPost("{tenderId}/publish")]
        [Authorize(Roles = nameof(RoleType.ProcurementOfficer))]
        public async Task<IActionResult> PublishTender(int tenderId)
        {
            var result = await _mediator.Send(new PublishTenderCommand(tenderId));
            if(!result)
                return NotFound("Tender not found or could not be published.");

            return Ok("Tender published successfully.");
        }


        /// <summary>
        /// Uploads a document for a specific tender.
        /// </summary>
        /// <param name="tenderId">The ID of the tender.</param>
        /// <param name="file">The file to upload.</param>
        /// <returns>Success message if uploaded successfully.</returns>
        [HttpPost("{tenderId}/documents")]
        public async Task<IActionResult> UploadDocument(int tenderId, IFormFile file)
        {
            if(file == null || file.Length == 0)
                return BadRequest("Invalid file.");

            var result = await _mediator.Send(new UploadTenderDocumentCommand(tenderId, file));
            if(!result)
                return NotFound("Tender not found.");

            return Ok(new { Message = "Document uploaded successfully." });
        }

        /// <summary>
        /// Deletes a document associated with a tender.
        /// </summary>
        /// <param name="documentId">The ID of the document to delete.</param>
        /// <returns>No content if successful.</returns>
        [HttpDelete("documents/{documentId}")]
        public async Task<IActionResult> DeleteTenderDocument(int documentId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _mediator.Send(new DeleteTenderDocumentCommand(documentId, userId));

            if (!result)
                return NotFound("Document not found or you do not have permission to delete it.");

            return NoContent();
        }

        /// <summary>
        /// Scores a bid for a specific tender.
        /// </summary>
        /// <param name="tenderId">The ID of the tender.</param>
        /// <param name="bidId">The ID of the bid.</param>
        /// <param name="command">The command containing scoring details.</param>
        /// <returns>Ok if successful, BadRequest otherwise.</returns>
        [HttpPost("{tenderId}/bids/{bidId}/score")]
        [Authorize(Roles = nameof(RoleType.Evaluator))]
        public async Task<IActionResult> ScoreBid(int tenderId, int bidId, [FromBody] ScoreBidCommand command)
        {
            if (tenderId != command.TenderId || bidId != command.BidId)
                return BadRequest("Invalid tender or bid ID.");

            var result = await _mediator.Send(command);
            return result ? Ok() : BadRequest("Failed to score bid.");
        }

        /// <summary>
        /// Awards a tender to a specific bid.
        /// </summary>
        /// <param name="tenderId">The ID of the tender.</param>
        /// <param name="command">The command containing award details.</param>
        /// <returns>Ok if successful, BadRequest otherwise.</returns>
        [HttpPost("{tenderId}/award")]
        [Authorize(Roles = nameof(RoleType.Evaluator))]
        public async Task<IActionResult> AwardTender(int tenderId, [FromBody] AwardTenderCommand command)
        {
            if (tenderId != command.TenderId)
                return BadRequest("Invalid tender ID.");

            var result = await _mediator.Send(command);
            return result ? Ok() : BadRequest("Failed to award tender.");
        }
    }
}


