using Application.Interfaces;

namespace Persistence.Database;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext, IShortenedUrlRepository shortenedUrls)
    {
        _dbContext = dbContext;
        ShortenedUrls = shortenedUrls;
    }

    public IShortenedUrlRepository ShortenedUrls { get; }
    
    public int SaveChanges() => _dbContext.SaveChanges();
}