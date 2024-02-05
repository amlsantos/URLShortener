﻿using CSharpFunctionalExtensions;
using Entity = Domain.Common.Entity;

namespace Persistence.Database;

public abstract class Repository<T> where T : Entity
{
    protected readonly ApplicationDbContext Context;
    protected Repository(ApplicationDbContext context) => Context = context;
    
    public async Task<Maybe<T>> GetById(long id)
    {
        var result = await Context.Set<T>().FindAsync(id);
        return Maybe.From<T>(result);
    }

    protected async Task Add(T entity)
    {
        await Context.Set<T>().AddAsync(entity);
    }
}