using Application.Interfaces;
using Application.UseCases.Urls.Commands;
using Application.UseCases.Urls.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Urls.Contracts;

namespace Presentation.Urls;

[ApiController]
[Route("[controller]")]
public class UrlShortenerController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IConsoleLogger _logger;
    
    public UrlShortenerController(IMediator mediator, IConsoleLogger logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("[action]")]
    public async Task<ShortenUrlResponse> Get(string shortUrl)
    {
        _logger.LogInformation($"");
        
        var query = new GetUrl { ShortUrl = shortUrl };
        var response = await _mediator.Send(query);
        
        return new ShortenUrlResponse
        {
            OriginalUrl = response.LongUrl.AsString(),
            ShortenUrl = response.ShortUrl.AsString()
        };
    }
    
    [HttpPost("[action]")]
    public async Task<ShortenUrlResponse> Create(ShortenUrlRequest request)
    {
        var command = new CreateUrl { Url = request.Url };
        var response = await _mediator.Send(command);
        
        return new ShortenUrlResponse
        {
            OriginalUrl = response.LongUrl.AsString(),
            ShortenUrl = response.ShortUrl.AsString()
        };
    }
}