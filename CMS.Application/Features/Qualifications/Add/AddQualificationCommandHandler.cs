using AutoMapper;
using CMS.Application.Abstractions.Authentication;
using CMS.Application.Abstractions.Data;
using CMS.Application.Abstractions.Messaging;
using CMS.Application.Features.DoctorProfiles;
using CMS.Application.Features.Users;
using CMS.Domain.Modules.Qualifications;
using CSharpFunctionalExtensions;

namespace CMS.Application.Features.Qualifications.Add;

public sealed class AddQualificationCommandHandler
    (
        IDoctorProfileRepository doctorProfileRepository,
        IUserContext userContext,
        IMapper mapper,
        IUnitOfWork unitOfWork
    ) 
    : ICommandHandler<AddQualificationCommand, UnitResult<Error>>
{
    public async Task<UnitResult<Error>> Handle(AddQualificationCommand request, CancellationToken cancellationToken)
    {
        var userId = userContext.GetUserId();

        var doctorProfile = await doctorProfileRepository.GetByUserIdAsync(userId, cancellationToken);

        if (doctorProfile is null) return UnitResult.Failure(UserErrors.UserNotFoundById);

        var qualification = mapper.Map<Qualification>(request.Data);

        doctorProfile.Qualifications.Add(qualification);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return UnitResult.Success<Error>();
    }
}
