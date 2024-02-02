﻿using Domain.Urls;

namespace Application.Interfaces;

public interface IShortenedUrlRepository
{
    public ShortenedUrl? GetById(long id);
    public ShortenedUrl? Get(Url url);

    public bool HasCode(Code code);
    public bool HasUrl(Url url);
    
    public void Add(ShortenedUrl entity);
}