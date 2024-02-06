using Application.Interfaces;

namespace Persistence.Database;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext, IShortenedUrlRepository shortenedUrls)
    {
        _dbContext = dbContext;
        ShortUrls = shortenedUrls;
    }

    public IShortenedUrlRepository ShortUrls { get; }
    
    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}