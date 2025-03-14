using CMS.Application.Abstractions.Messaging;
using CSharpFunctionalExtensions;

namespace CMS.Application.Features.DoctorProfiles.UpdateBio;

public record UpdateBioCommand(UpdateBioRequest Data) : ICommand<UnitResult<Error>>;