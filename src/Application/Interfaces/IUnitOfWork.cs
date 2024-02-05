namespace Application.Interfaces;

public interface IUnitOfWork
{
    public IShortenedUrlRepository ShortenedUrls { get; }

    Task<int> SaveChangesAsync();
}