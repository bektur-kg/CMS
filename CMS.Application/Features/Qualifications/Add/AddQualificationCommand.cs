using CMS.Application.Abstractions.Messaging;
using CSharpFunctionalExtensions;

namespace CMS.Application.Features.Qualifications.Add;

public record AddQualificationCommand(AddQualificationRequest Data) : ICommand<UnitResult<Error>>;
