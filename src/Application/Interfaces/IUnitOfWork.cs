namespace Application.Interfaces;

public interface IUnitOfWork
{
    public IShortenedUrlRepository ShortUrls { get; }

    Task<int> SaveChangesAsync();
}