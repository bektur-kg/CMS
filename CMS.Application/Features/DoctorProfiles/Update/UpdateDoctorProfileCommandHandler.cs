using AutoMapper;
using CMS.Application.Abstractions.Authentication;
using CMS.Application.Abstractions.Data;
using CMS.Application.Abstractions.Messaging;
using CMS.Application.Features.Users;
using CSharpFunctionalExtensions;

namespace CMS.Application.Features.DoctorProfiles.Update;

internal sealed class UpdateDoctorProfileCommandHandler
    (
        IDoctorProfileRepository doctorProfileRepository,
        IUserContext userContext,
        IUnitOfWork unitOfWork,
        IMapper mapper
    )
    : ICommandHandler<UpdateDoctorProfileCommand, UnitResult<Error>>
{
    public async Task<UnitResult<Error>> Handle(UpdateDoctorProfileCommand request, CancellationToken cancellationToken)
    {
        var userId = userContext.GetUserId();

        var doctorProfile = await doctorProfileRepository.GetByUserIdAsync(userId, cancellationToken);

        if (doctorProfile == null) return UnitResult.Failure(UserErrors.UserNotFoundById);

        mapper.Map(request.Data, doctorProfile);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return UnitResult.Success<Error>();
    }
}
