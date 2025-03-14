using CSharpFunctionalExtensions;
using System.Threading;

namespace CMS.Application.Abstractions.Data;

public interface IReadRepository<TEntity> where TEntity : Entity
{
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default);

    Task<TEntity?> GetByIdWithNoTrackingAsync(long id, CancellationToken cancellationToken = default);
}