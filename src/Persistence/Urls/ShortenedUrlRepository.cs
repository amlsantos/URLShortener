using Application.Interfaces;
using CSharpFunctionalExtensions;
using Domain.Urls;
using Microsoft.EntityFrameworkCore;
using Persistence.Common;

namespace Persistence.Urls;

public class ShortenedUrlRepository : Repository<ShortenedUrl>, IShortenedUrlRepository
{
    public ShortenedUrlRepository(ApplicationDbContext context) : base(context) { }
    
    public async Task<Maybe<ShortenedUrl>> GetAsync(Url url)
    {
        var result = await Context.
            ShortenedUrls.
            FirstOrDefaultAsync(x => x.ShortUrl == url);
        return Maybe.From<ShortenedUrl>(result);
    }

    public async Task<bool> HasCodeAsync(Code code)
    {
        return await Context.ShortenedUrls.AnyAsync(x => x.Code == code);
    }

    public async Task<bool> HasUrlAsync(Url url)
    {
        return await Context.ShortenedUrls.AnyAsync(x => x.LongUrl == url);
    }

    public async Task AddAsync(ShortenedUrl url)
    {
        await base.AddAsync(url);
    }
}