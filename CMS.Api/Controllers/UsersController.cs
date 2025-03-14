using CMS.Application.Features.Users.Login;
using CMS.Application.Features.Users.Register;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace CMS.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(
        [FromBody] RegisterUserRequest request,
        [FromServices] IValidator<RegisterUserRequest> validator,
        CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

        var command = new RegisterUserCommand(request);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Created() : BadRequest(result.Error);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(
        [FromBody] LoginUserRequest request,
        [FromServices] IValidator<LoginUserRequest> validator,
        CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

        var query = new LoginUserQuery(request);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
