using CMS.Application.Abstractions.Authentication;
using CMS.Application.Abstractions.Messaging;
using CSharpFunctionalExtensions;

namespace CMS.Application.Features.Users.Login;

internal sealed class LoginUserQueryHandler
    (
        IUserRepository userRepository,
        IJwtProvider jwtProvider,
        IPasswordManager passwordManager
    ) : IQueryHandler<LoginUserQuery, Result<LoginUserTokenResponse, Error>>
{
    public async Task<Result<LoginUserTokenResponse, Error>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync(request.Data.Email, cancellationToken);

        if (user is null) return Result.Failure<LoginUserTokenResponse, Error>(UserErrors.WrongCredentials);

        var isPasswordVerified = passwordManager.Verify(request.Data.Password, user.PasswordHash);

        if (!isPasswordVerified) return Result.Failure<LoginUserTokenResponse, Error>(UserErrors.WrongCredentials);

        var token = jwtProvider.Generate(user);

        var response = new LoginUserTokenResponse { AccessToken = token };

        return Result.Success<LoginUserTokenResponse, Error>(response);
    }
}
