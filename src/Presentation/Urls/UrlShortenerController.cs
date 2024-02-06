using Application.Interfaces;
using Application.UseCases.Urls.Commands;
using Application.UseCases.Urls.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;
using Presentation.Urls.Contracts;

namespace Presentation.Urls;

[ApiController]
[Route("[controller]")]
public class UrlShortenerController : BaseController
{
    private readonly ISender _mediator;
    private readonly IConsoleLogger _logger;
    
    public UrlShortenerController(ISender mediator, IConsoleLogger logger, IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> Get(string shortUrl)
    {
        _logger.LogInformation($"starting UrlShortenerController.Get:{shortUrl}");
        
        var query = new GetUrl { ShortUrl = shortUrl };
        var response = await _mediator.Send(query);
        if (response.IsFailure)
        {
            _logger.LogError($"error UrlShortenerController.Get:{shortUrl}, error: {response.Error}");
            return Error(response.Error);
        }

        _logger.LogInformation($"success UrlShortenerController.Get:{shortUrl}: {response.Value.LongUrl}");
        var dto = new ShortenUrlResponse
        {
            OriginalUrl = response.Value.LongUrl,
            ShortenUrl = response.Value.ShortUrl
        };
        return await Success(dto);
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(ShortenUrlRequest request)
    {
        _logger.LogInformation($"starting UrlShortenerController.Create:{request.Url}");
        
        var command = new CreateUrl { Url = request.Url };
        var response = await _mediator.Send(command);
        if (response.IsFailure)
        {
            _logger.LogError($" error UrlShortenerController.Create:{request.Url}, error: {response.Error}");
            return Error(response.Error);
        }
        
        _logger.LogInformation($"success UrlShortenerController.Create:{request.Url}, value: {response.Value.LongUrl}");
        var dto = new ShortenUrlResponse
        {
            OriginalUrl = response.Value.LongUrl,
            ShortenUrl = response.Value.ShortUrl
        };
        return await Success(dto);
    }
}