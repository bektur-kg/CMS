using CSharpFunctionalExtensions;

namespace CMS.Application.Abstractions;

public interface IWriteRepository<TEntity> where TEntity : Entity
{
    void Add(TEntity entity);

    void Remove(TEntity entity);

    void Update(TEntity entity);
}
