using CMS.Application.Features.DoctorProfiles.GetAll;
using CMS.Application.Features.DoctorProfiles.GetDetailedById;
using CMS.Application.Features.DoctorProfiles.Update;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace CMS.Api.Controllers;

[ApiController]
[Route("api")]
public class DoctorProfilesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [Authorize(Roles = "Doctor")]
    [HttpPatch("doctor-profiles/current")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateDoctorProfileRequest request, 
        [FromServices] IValidator<UpdateDoctorProfileRequest> validator,
        CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

        var command = new UpdateDoctorProfileCommand(request);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    [Authorize]
    [HttpGet("doctor-profiles")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken) // todo: add filtering, sorting and pagination
    {
        var query = new GetAllDoctorProfilesQuery();

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [Authorize]
    [HttpGet("doctor-profiles/{id:long}")]
    public async Task<IActionResult> GetDetailedById(long id, CancellationToken cancellationToken)
    {
        var query = new GetDetailedDoctorProfileQuery(id);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
