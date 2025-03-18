using CMS.Application.Abstractions.Messaging;
using CSharpFunctionalExtensions;

namespace CMS.Application.Features.TimeSlots.Create;

public record CreateTimeSlotCommand(CreateTimeSlotRequest Data) : ICommand<UnitResult<Error>>;