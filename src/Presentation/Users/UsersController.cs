using Application.Interfaces;
using Application.UseCases.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;
using Presentation.Users.Contracts;

namespace Presentation.Users;

[ApiController]
[Route("[controller]")]
public class UsersController : BaseController
{
    private readonly ISender _mediator;
    private readonly IConsoleLogger _logger;
    
    public UsersController(ISender mediator, IConsoleLogger logger, IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        _logger.LogInformation($"starting UsersController.Login:{request.Email}");
        
        var command = new Login { Email = request.Email };
        
        var responseOrError = await _mediator.Send(command);
        if (responseOrError.IsFailure)
        {
            _logger.LogError($" error UsersController.Login:{request.Email}, error: {responseOrError.Error}");
            return Failure(responseOrError.Error);
        }
        
        _logger.LogInformation($"success UsersController.Login:{request.Email}:");
        
        var token = responseOrError.Value;
        var response = new LoginResponse
        {
            Token = token.AsString()
        };
        
        return await Success(response);
    }
}