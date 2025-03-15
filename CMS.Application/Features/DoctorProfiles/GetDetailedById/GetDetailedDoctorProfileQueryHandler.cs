using AutoMapper;
using CMS.Application.Abstractions.Messaging;
using CSharpFunctionalExtensions;

namespace CMS.Application.Features.DoctorProfiles.GetDetailedById;

internal sealed class GetDetailedDoctorProfileQueryHandler
    (
        IMapper mapper,
        IDoctorProfileRepository doctorProfileRepository
    )
    : IQueryHandler<GetDetailedDoctorProfileQuery, Result<GetDetailedDoctorProfileResponse>>
{
    public async Task<Result<GetDetailedDoctorProfileResponse>> Handle(GetDetailedDoctorProfileQuery request, CancellationToken cancellationToken)
    {
        var doctorProfile = await doctorProfileRepository.GetByIdWithInlcudeAndNoTrackingAsync(
            request.DoctorProfileId,
            includeUser: true,
            includeQualifications: true,
            includeTimeSlots: true,
            cancellationToken: cancellationToken);

        var mappedDoctorProfile = mapper.Map<GetDetailedDoctorProfileResponse>(doctorProfile);

        return Result.Success(mappedDoctorProfile);
    }
}
