using CSharpFunctionalExtensions;

namespace CMS.Application.Abstractions;

public interface IReadRepository<TEntity> where TEntity : Entity
{
    Task<List<TEntity>> GetAllAsync();

    Task<TEntity?> GetByIdAsync(long id);

    Task<TEntity?> GetByIdWithNoTrackingAsync(long id);
}