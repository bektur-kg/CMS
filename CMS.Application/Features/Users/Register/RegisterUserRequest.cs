using CMS.Domain.Modules.Users;

namespace CMS.Application.Features.Users.Register;

public record RegisterUserRequest
{
    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Patronymic { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public UserType UserType { get; set; }
}
