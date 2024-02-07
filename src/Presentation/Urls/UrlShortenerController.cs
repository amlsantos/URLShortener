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
        var responseOrError = await _mediator.Send(query);
        if (responseOrError.IsFailure)
        {
            _logger.LogError($"error UrlShortenerController.Get:{shortUrl}, error: {responseOrError.Error}");
            return Failure(responseOrError.Error);
        }

        _logger.LogInformation($"success UrlShortenerController.Get:{shortUrl}: {responseOrError.Value.LongUrl}");
        var response = new ShortenUrlResponse
        {
            OriginalUrl = responseOrError.Value.LongUrl,
            ShortenUrl = responseOrError.Value.ShortUrl
        };
        
        return await Success(response);
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(ShortenUrlRequest request)
    {
        _logger.LogInformation($"starting UrlShortenerController.Create:{request.Url}");
        
        var command = new CreateUrl { Url = request.Url };
        var responseOrError = await _mediator.Send(command);
        if (responseOrError.IsFailure)
        {
            _logger.LogError($" error UrlShortenerController.Create:{request.Url}, error: {responseOrError.Error}");
            return Failure(responseOrError.Error);
        }
        
        _logger.LogInformation($"success UrlShortenerController.Create:{request.Url}, value: {responseOrError.Value.LongUrl}");
        var response = new ShortenUrlResponse
        {
            OriginalUrl = responseOrError.Value.LongUrl,
            ShortenUrl = responseOrError.Value.ShortUrl
        };
        
        return await Success(response);
    }
}