using CSharpFunctionalExtensions;

namespace CMS.Application.Abstractions.Data;

public interface IWriteRepository<TEntity> where TEntity : Entity
{
    void Add(TEntity entity);

    void Remove(TEntity entity);

    void Update(TEntity entity);
}
