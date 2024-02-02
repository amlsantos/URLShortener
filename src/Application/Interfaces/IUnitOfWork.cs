namespace Application.Interfaces;

public interface IUnitOfWork
{
    public IShortenedUrlRepository ShortenedUrls { get; }

    int SaveChanges();
}