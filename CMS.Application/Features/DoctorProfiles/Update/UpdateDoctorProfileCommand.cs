using CMS.Application.Abstractions.Messaging;
using CSharpFunctionalExtensions;

namespace CMS.Application.Features.DoctorProfiles.Update;

public record UpdateDoctorProfileCommand(UpdateDoctorProfileRequest Data) : ICommand<UnitResult<Error>>;