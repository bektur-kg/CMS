using CMS.Application.Abstractions.Authentication;
using CMS.Application.Abstractions.Data;
using CMS.Application.Abstractions.Messaging;
using CMS.Application.Features.DoctorProfiles;
using CMS.Domain.Modules.TimeSlots;
using CSharpFunctionalExtensions;

namespace CMS.Application.Features.TimeSlots.Create;

internal sealed class CreateTimeSlotCommandHandler
    (
        IUserContext userContext,
        IUnitOfWork unitOfWork,
        IDoctorProfileRepository doctorProfileRepository,
        ITimeSlotsRepository timeSlotRepository
    )
    : ICommandHandler<CreateTimeSlotCommand, UnitResult<Error>>
{
    public async Task<UnitResult<Error>> Handle(CreateTimeSlotCommand request, CancellationToken cancellationToken)
    {
        var userId = userContext.GetUserId();
        var doctorProfile = await doctorProfileRepository.GetByUserIdAsync(userId, cancellationToken);

        if (doctorProfile == null) return UnitResult.Failure(DoctorProfileErrors.DoctorProfileNotFoundById);

        var overlappingTimeSlot = await timeSlotRepository.IsOverlappingAsync(request.Data.StartTime, request.Data.EndTime);

        if (overlappingTimeSlot) return UnitResult.Failure(TimeSlotErrors.OverlappingTimeSlot);

        var timeSlot = new TimeSlot
        {
            StartTime = request.Data.StartTime,
            EndTime = request.Data.EndTime
        };

        doctorProfile.TimeSlots.Add(timeSlot);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return UnitResult.Success<Error>();
    }
}
