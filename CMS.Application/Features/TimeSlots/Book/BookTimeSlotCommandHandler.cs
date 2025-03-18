using CMS.Application.Abstractions.Data;
using CMS.Application.Abstractions.Messaging;
using CSharpFunctionalExtensions;

namespace CMS.Application.Features.TimeSlots.Book;

internal sealed class BookTimeSlotCommandHandler
    (
        ITimeSlotsRepository timeSlotsRepository,
        IUnitOfWork unitOfWork
    ) : ICommandHandler<BookTimeSlotCommand, UnitResult<Error>>
{
    public async Task<UnitResult<Error>> Handle(BookTimeSlotCommand request, CancellationToken cancellationToken)
    {
        var timeSlot = await timeSlotsRepository.GetByIdAsync(request.TimeSlotId, cancellationToken);

        if (timeSlot is null) return UnitResult.Failure(TimeSlotErrors.TimeSlotNotFoundById);
        if (timeSlot.IsBooked) return UnitResult.Failure(TimeSlotErrors.TimeSlotAlreadyBooked);

        timeSlot.IsBooked = true;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return UnitResult.Success<Error>();
    }
}
