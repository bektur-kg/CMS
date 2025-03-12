using CMS.Application.Features.Users;
using CMS.Domain.Modules.Users;
using CMS.Infrastructure.DbContexts;
using CMS.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Modules.Users;

internal sealed class UserRepository(AppDbContext dbContext) : Repository<User>(dbContext), IUserRepository
{
    public Task<bool> DoesEmailExistAsync(string email, CancellationToken cancellationToken)
    {
        return DbContext.Users.AnyAsync(u => u.Email == email, cancellationToken);
    }
}
