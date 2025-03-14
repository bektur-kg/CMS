using CMS.Application.Abstractions.Authentication;
using CMS.Application.Abstractions.Data;
using CMS.Application.Abstractions.Messaging;
using CMS.Application.Features.Users;
using CSharpFunctionalExtensions;

namespace CMS.Application.Features.DoctorProfiles.UpdateBio;

internal sealed class UpdateBioCommandHandler
    (
        IDoctorProfileRepository doctorProfileRepository,
        IUserContext userContext,
        IUnitOfWork unitOfWork
    ) 
    : ICommandHandler<UpdateBioCommand, UnitResult<Error>>
{
    public async Task<UnitResult<Error>> Handle(UpdateBioCommand request, CancellationToken cancellationToken)
    {
        var userId = userContext.GetUserId();
        
        var doctorProfile = await doctorProfileRepository.GetByUserIdAsync(userId, cancellationToken);

        if (doctorProfile == null) return UnitResult.Failure(UserErrors.UserNotFoundById);

        doctorProfile.Bio = request.Data.Bio;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return UnitResult.Success<Error>();
    }
}
