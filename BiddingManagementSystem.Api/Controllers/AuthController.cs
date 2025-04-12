using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BiddingManagementSystem.Application.Features.Authentication.Commands.RegisterUser;
using BiddingManagementSystem.Application.Features.Authentication.Queries.LoginUser;

namespace BiddingManagementSystem.Api.Controllers;

/// <summary>
/// Controller responsible for handling authentication-related operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Registers a new user in the system.
    /// </summary>
    /// <param name="command">The command containing user registration details.</param>
    /// <returns>Returns the registered user's id along with a token.</returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    /// <summary>
    /// Logs in an existing user.
    /// </summary>
    /// <param name="query">The query containing user login details.</param>
    /// <returns>Returns a token for the authenticated user.</returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// Resets the password for a user.
    /// </summary>
    /// <param name="command">The command containing password reset details.</param>
    /// <returns>Returns no content upon successful password reset.</returns>
    [HttpPost("reset-password")]
    [Authorize]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}


