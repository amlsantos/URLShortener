﻿using Application.Interfaces;
using Domain.Urls;
using Persistence.Database;

namespace Persistence.Urls;

public class ShortenedUrlRepository : Repository<ShortenedUrl>, IShortenedUrlRepository
{
    public ShortenedUrlRepository(ApplicationDbContext context) : base(context) {}
    
    public ShortenedUrl? GetById(long id) => base.GetById(id);

    public ShortenedUrl? Get(Url url)
    {
        return Context.ShortenedUrls.SingleOrDefault(x => x.LongUrl == url);
    }

    public bool HasCode(Code code)
    {
        return Context.ShortenedUrls.Any(x => x.Code == code);
    }

    public bool HasUrl(Url url)
    {
        return Context.ShortenedUrls.Any(x => x.LongUrl == url);
    }

    public void Add(ShortenedUrl entity)
    {
        base.Add(entity);
    }
}