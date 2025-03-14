using CMS.Domain.Modules.Users;

namespace CMS.Application.Abstractions.Authentication;

public interface IJwtProvider
{
    string Generate(User user);
}