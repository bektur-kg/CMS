using CMS.Application.Services;
using CMS.Infrastructure.DbContexts;

namespace CMS.Infrastructure.Services;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) 
        => dbContext.SaveChangesAsync(cancellationToken);
}
