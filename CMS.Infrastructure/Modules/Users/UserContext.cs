using CMS.Application.Abstractions.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CMS.Infrastructure.Modules.Users;

internal sealed class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public long GetUserId()
    {
        var userId = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        return userId == null ? throw new ApplicationException("User id is unavailable") : long.Parse(userId);
    }
}
