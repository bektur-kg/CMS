using AutoMapper;
using CMS.Application.Abstractions;
using CMS.Application.Services;
using CMS.Domain.Modules.Users;
using CSharpFunctionalExtensions;

namespace CMS.Application.Features.Users.Register;

internal sealed class RegisterUserCommandHandler
    (
        IUserRepository userRepository,
        IPasswordManager passwordManager,
        IMapper mapper,
        IUnitOfWork unitOfWork
    ) 
    : ICommandHandler<RegisterUserCommand, UnitResult<Error>>
{
    public async Task<UnitResult<Error>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request.Data);

        var passwordHash = passwordManager.Hash(request.Data.Password);

        user.PasswordHash = passwordHash;
        user.CreatedAt = DateTime.UtcNow;

        userRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return UnitResult.Success<Error>();
    }
}
