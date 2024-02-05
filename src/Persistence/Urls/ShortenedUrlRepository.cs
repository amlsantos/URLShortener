using Application.Interfaces;
using CSharpFunctionalExtensions;
using Domain.Urls;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Persistence.Urls;

public class ShortenedUrlRepository : Repository<ShortenedUrl>, IShortenedUrlRepository
{
    public ShortenedUrlRepository(ApplicationDbContext context) : base(context) {}
    
    public async Task<Maybe<ShortenedUrl>> Get(Url url)
    {
        var result = await Context.
            ShortenedUrls.
            FirstOrDefaultAsync(x => x.ShortUrl == url);
        return Maybe.From<ShortenedUrl>(result);
    }

    public async Task<bool> HasCode(Code code)
    {
        return await Context.ShortenedUrls.AnyAsync(x => x.Code == code);
    }

    public async Task<bool> HasUrl(Url url)
    {
        return await Context.ShortenedUrls.AnyAsync(x => x.LongUrl == url);
    }

    public async Task AddAsync(ShortenedUrl url)
    {
        await Add(url);
    }
}