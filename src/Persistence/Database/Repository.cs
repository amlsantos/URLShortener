using Domain.Common;

namespace Persistence.Database;

public abstract class Repository<T> where T : Entity
{
    protected readonly ApplicationDbContext Context;
    protected Repository(ApplicationDbContext context) => Context = context;
    
    public T? GetById(long id) => Context.Set<T>().Find(id);
    
    public void Add(T entity) => Context.Set<T>().Add(entity);
}