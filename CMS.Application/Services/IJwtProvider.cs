using CMS.Domain.Modules.Users;

namespace CMS.Application.Services;

public interface IJwtProvider
{
    string Generate(User user);
}