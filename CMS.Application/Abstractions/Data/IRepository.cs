using CSharpFunctionalExtensions;

namespace CMS.Application.Abstractions.Data;

public interface IRepository<TEntity> : IReadRepository<TEntity>, IWriteRepository<TEntity>
    where TEntity : Entity;