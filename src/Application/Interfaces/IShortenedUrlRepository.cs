using CSharpFunctionalExtensions;
using Domain.Urls;

namespace Application.Interfaces;

public interface IShortenedUrlRepository
{
    public Maybe<ShortenedUrl> Get(Url url);

    public bool HasCode(Code code);
    public bool HasUrl(Url url);
    
    public void Add(ShortenedUrl url);
}