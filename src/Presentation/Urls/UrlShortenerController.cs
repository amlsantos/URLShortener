using Application.UseCases.Urls.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Urls.Contracts;

namespace Presentation.Urls;

[ApiController]
[Route("[controller]")]
public class UrlShortenerController : ControllerBase
{
    private readonly IMediator _mediator;

    public UrlShortenerController(IMediator mediator) => _mediator = mediator;

    [HttpPost("[action]")]
    public async Task<ShortenUrlResponse> Create(ShortenUrlRequest request)
    {
        var command = new CreateUrlShortener
        {
            Url = request.Url
        };

        var response = await _mediator.Send(command);
        
        return new ShortenUrlResponse
        {
            Url = response.ShortUrl.AsString()
        };
    }
}