using CMS.Application.Abstractions.Messaging;
using CSharpFunctionalExtensions;

namespace CMS.Application.Features.TimeSlots.Book;

public record BookTimeSlotCommand(long TimeSlotId) : ICommand<UnitResult<Error>>;
