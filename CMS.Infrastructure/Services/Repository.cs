using CMS.Application.Abstractions;
using CMS.Infrastructure.DbContexts;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Services;

public abstract class Repository<TEntity>(AppDbContext dbContext) : IRepository<TEntity> where TEntity : Entity
{
    protected AppDbContext DbContext = dbContext;

    public Task<List<TEntity>> GetAllAsync() => DbContext
        .Set<TEntity>()
        .AsQueryable()
        .ToListAsync();

    public Task<TEntity?> GetByIdAsync(long id) => DbContext
        .Set<TEntity>()
        .AsQueryable()
        .FirstOrDefaultAsync(entity => entity.Id == id);

    public Task<TEntity?> GetByIdWithNoTrackingAsync(long id) => DbContext
        .Set<TEntity>()
        .AsNoTracking()
        .FirstOrDefaultAsync(entity => entity.Id == id);

    public void Add(TEntity entity) => DbContext.Add(entity);

    public void Remove(TEntity entity) => DbContext
        .Set<TEntity>()
        .Remove(entity);

    public void Update(TEntity entity) => DbContext
        .Set<TEntity>()
        .Update(entity);
}
