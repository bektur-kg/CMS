using CMS.Application.Abstractions.Messaging;
using CSharpFunctionalExtensions;

namespace CMS.Application.Features.DoctorProfiles.GetAll;

public record GetAllDoctorProfilesQuery : IQuery<Result<List<GetDoctorProfileResponse>>>;
