using CMS.Application.Abstractions;
using CMS.Domain.Modules.Users;

namespace CMS.Application.Features.Users;

public interface IUserRepository : IReadRepository<User>, IWriteRepository<User>
{
    Task<bool> DoesEmailExistAsync(string email, CancellationToken cancellationToken);
}
