using CMS.Application.Abstractions.Messaging;

namespace CMS.Application.Features.Users;

public static class UserErrors
{
    public static readonly Error WrongCredentials = new("User.WrongCredentials", "Wrong credentials");
    public static readonly Error UserNotFoundById = new("User.NotFoundById", "User by this id is not found");
}
