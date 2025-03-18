using CMS.Application.Features.TimeSlots.Book;
using CMS.Application.Features.TimeSlots.Create;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace CMS.Api.Controllers;

[ApiController]
[Route("api")]
public class TimeSlotsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [Authorize(Roles = "Doctor")]
    [HttpPost("time-slots")]
    public async Task<IActionResult> Create(
        [FromBody] CreateTimeSlotRequest request,
        [FromServices] IValidator<CreateTimeSlotRequest> validator,
        CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

        var command = new CreateTimeSlotCommand(request);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Created() : BadRequest(result.Error);
    }

    [Authorize(Roles = "Patient")]
    [HttpPost("time-slots/{id:long}/book")]
    public async Task<IActionResult> Book(long id, CancellationToken cancellationToken)
    {
        var command = new BookTimeSlotCommand(id);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Created() : BadRequest(result.Error);
    }
}
