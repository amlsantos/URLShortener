using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Urls.Contracts;

namespace Presentation.Urls;

[ApiController]
[Route("[controller]")]
public class UrlController : ControllerBase
{
    private readonly IMediator _mediator;

    public UrlController(IMediator mediator) => _mediator = mediator;

    [HttpGet("[action]")]
    public UrlResponse Get()
    {
        return new UrlResponse
        {
            Test = "test"
        };
    }
}