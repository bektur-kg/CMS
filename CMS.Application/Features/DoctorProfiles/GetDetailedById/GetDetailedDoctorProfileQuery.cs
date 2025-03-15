using CMS.Application.Abstractions.Messaging;
using CSharpFunctionalExtensions;

namespace CMS.Application.Features.DoctorProfiles.GetDetailedById;

public record GetDetailedDoctorProfileQuery(long DoctorProfileId) : IQuery<Result<GetDetailedDoctorProfileResponse>>;
