using CMS.Application.Abstractions.Messaging;
using CSharpFunctionalExtensions;

namespace CMS.Application.Features.Users.Register;

public record RegisterUserCommand(RegisterUserRequest Data) : ICommand<UnitResult<Error>>;