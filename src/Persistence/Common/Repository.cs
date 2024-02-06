using CSharpFunctionalExtensions;

namespace Persistence.Common;

public abstract class Repository<T> where T : Entity<Guid>
{
    protected readonly ApplicationDbContext Context;
    protected Repository(ApplicationDbContext context) => Context = context;
    
    public async Task<Maybe<T>> GetByIdAsync(long id)
    {
        var result = await Context.Set<T>().FindAsync(id);
        return Maybe.From<T>(result);
    }

    protected async Task AddAsync(T entity)
    {
        await Context.Set<T>().AddAsync(entity);
    }
}