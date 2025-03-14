namespace CMS.Application.Features.Users.Login;

public record LoginUserRequest
{
    public required string Email { get; set; }

    public required string Password { get; set; }
}
