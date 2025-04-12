using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BiddingManagementSystem.Application.Features.Users.Commands.GetUserByUsername;
using BiddingManagementSystem.Application.Features.Users.Commands.UpdateUserEmail;
using BiddingManagementSystem.Application.Features.Users.Commands.DeleteUser;
using BiddingManagementSystem.Application.Features.Users.Commands.UpdateUserAddress;
using BiddingManagementSystem.Application.Interfaces;
using BiddingManagementSystem.Domain.Enums;

namespace BiddingManagementSystem.Api.Controllers
{
    /// <summary>
    /// Controller responsible for managing user-related operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRoleService _roleService;

        public UsersController(IMediator mediator, IRoleService roleService)
        {
            _mediator = mediator;
            _roleService = roleService;
        }

        /// <summary>
        /// Retrieves a user by their username.
        /// </summary>
        /// <param name="username">The username of the user to retrieve.</param>
        /// <returns>Returns the user details if found, otherwise a 404 status.</returns>
        [HttpGet("{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var query = new GetUserByUsernameQuery(username);
            var user = await _mediator.Send(query);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        /// <summary>
        /// Updates the email address of a user.
        /// </summary>
        /// <param name="username">The username of the user to update.</param>
        /// <param name="newEmail">The new email address to set.</param>
        /// <returns>Returns no content upon successful update, otherwise a 404 status if the user is not found.</returns>
        [HttpPut("{username}")]
        public async Task<IActionResult> UpdateUserEmail(string username, [FromBody] string newEmail)
        {
            var command = new UpdateUserEmailCommand(username, newEmail);
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Updates the address of a user.
        /// </summary>
        /// <param name="username">The username of the user to update.</param>
        /// <param name="command">The command containing the new address details for the user.</param>
        /// <returns>Returns no content upon successful update, otherwise a 404 status if the user is not found.</returns>
        [HttpPut("{username}/address")]
        public async Task<IActionResult> UpdateUserAddress(string username, [FromBody] UpdateUserAddressCommand command)
        {
            if(command == null || command.NewAddress == null)
            {
                return BadRequest("Invalid address data.");
            }

            command.Username = username;
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes a user by their username.
        /// </summary>
        /// <param name="username">The username of the user to delete.</param>
        /// <returns>Returns no content upon successful deletion, otherwise a 404 status if the user is not found.</returns>
        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            var command = new DeleteUserCommand(username);
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Assigns a role to an existing user.
        /// </summary>
        /// <param name="username">The username of the user to assign the role to.</param>
        /// <param name="roleName">The name of the role to assign.</param>
        /// <returns>Returns no content upon successful role assignment, otherwise appropriate error responses.</returns>
        [HttpPost("{username}/assign-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole(string username, [FromBody] string roleName)
        {
            // Validate the role
            if (!Enum.TryParse<RoleType>(roleName, true, out var roleType))
            {
                return BadRequest($"Invalid role: {roleName}");
            }

            // Assign the role using the RoleService
            try
            {
                var user = await _mediator.Send(new GetUserByUsernameQuery(username));
                if (user == null)
                {
                    return NotFound($"User with username '{username}' not found.");
                }

                await _roleService.AssignRoleToUserAsync(user.Id, roleType.ToString());
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}


