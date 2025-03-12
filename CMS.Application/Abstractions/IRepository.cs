using CSharpFunctionalExtensions;

namespace CMS.Application.Abstractions;

public interface IRepository<TEntity> : IReadRepository<TEntity>, IWriteRepository<TEntity>
    where TEntity : Entity;