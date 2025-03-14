using CMS.Application.Features.DoctorProfiles.UpdateBio;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace CMS.Api.Controllers;

[Authorize(Roles = "Doctor")]
[ApiController]
[Route("api")]
public class DoctorProfilesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPatch("doctor-profile/bio")]
    public async Task<IActionResult> UpdateBio(
        [FromBody] UpdateBioRequest request, 
        [FromServices] IValidator<UpdateBioRequest> validator,
        CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

        var command = new UpdateBioCommand(request);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }
}
