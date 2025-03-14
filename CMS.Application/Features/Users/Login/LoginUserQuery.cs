using CMS.Application.Abstractions.Messaging;
using CSharpFunctionalExtensions;

namespace CMS.Application.Features.Users.Login;

public record LoginUserQuery(LoginUserRequest Data) : IQuery<Result<LoginUserTokenResponse, Error>>;