using AutoMapper;
using CMS.Application.Abstractions.Messaging;
using CSharpFunctionalExtensions;

namespace CMS.Application.Features.DoctorProfiles.GetAll;

internal sealed class GetAllDoctorProfilesQueryHandler
    (
        IDoctorProfileRepository doctorProfileRepository,
        IMapper mapper
    )
    : IQueryHandler<GetAllDoctorProfilesQuery, Result<List<GetDoctorProfileResponse>>>
{
    public async Task<Result<List<GetDoctorProfileResponse>>> Handle(GetAllDoctorProfilesQuery request, CancellationToken cancellationToken)
    {
        var doctorProfiles = await doctorProfileRepository
            .GetAllWithIncludeAndNoTracking(includeUser: true, cancellationToken: cancellationToken);

        var doctorProfilesResponse = mapper.Map<List<GetDoctorProfileResponse>>(doctorProfiles);

        return Result.Success(doctorProfilesResponse);
    }
}
