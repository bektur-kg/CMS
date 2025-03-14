using CMS.Application.Abstractions.Data;
using CMS.Domain.Modules.Users;

namespace CMS.Application.Features.Users;

public interface IUserRepository : IRepository<User>
{
    Task<bool> DoesEmailExistAsync(string email, CancellationToken cancellationToken);

    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
}
