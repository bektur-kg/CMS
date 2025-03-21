﻿using CMS.Application.Abstractions.Data;
using CMS.Infrastructure.DbContexts;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Services;

public abstract class Repository<TEntity>(AppDbContext dbContext) : IRepository<TEntity> where TEntity : Entity
{
    protected AppDbContext DbContext = dbContext;

    public Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken) => DbContext
        .Set<TEntity>()
        .AsQueryable()
        .ToListAsync(cancellationToken);

    public Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken) => DbContext
        .Set<TEntity>()
        .AsQueryable()
        .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);

    public Task<TEntity?> GetByIdWithNoTrackingAsync(long id, CancellationToken cancellationToken) => DbContext
        .Set<TEntity>()
        .AsNoTracking()
        .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);

    public void Add(TEntity entity) => DbContext.Add(entity);

    public void Remove(TEntity entity) => DbContext
        .Set<TEntity>()
        .Remove(entity);

    public void Update(TEntity entity) => DbContext
        .Set<TEntity>()
        .Update(entity);
}
