using Application.Interfaces;
using Persistence.Urls;

namespace Persistence.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        ShortUrls = new ShortenedUrlRepository(dbContext);
    }

    public IShortenedUrlRepository ShortUrls { get; }
    
    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}