using FluentValidation;

namespace CMS.Application.Features.TimeSlots.Create;

public class CreateTimeSlotRequestValidator : AbstractValidator<CreateTimeSlotRequest>
{
    public CreateTimeSlotRequestValidator()
    {
        RuleFor(ts => ts.StartTime)
            .NotEmpty().WithMessage("Start time is required")
            .GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("Start time must be in the future")
            .LessThan(ts => ts.EndTime).WithMessage("Start time must be before end time");

        RuleFor(ts => ts.EndTime)
            .NotEmpty().WithMessage("End time is required")
            .GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("End time must be in the future")
            .GreaterThan(ts => ts.StartTime).WithMessage("End time must be after start time");
    }
}
