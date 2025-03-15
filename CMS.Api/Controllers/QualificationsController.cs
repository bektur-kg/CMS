using CMS.Application.Features.Qualifications.Add;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace CMS.Api.Controllers;

[Authorize(Roles = "Doctor")]
[ApiController]
[Route("api")]
public class QualificationsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost("doctor-profile/qualifications")]
    public async Task<IActionResult> Add(
    [FromBody] AddQualificationRequest request,
    [FromServices] IValidator<AddQualificationRequest> validator,
    CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

        var command = new AddQualificationCommand(request);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }
}
