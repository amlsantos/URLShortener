using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Utils;

public abstract class BaseController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    protected BaseController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    
    protected async Task<IActionResult> Success()
    {
        await _unitOfWork.SaveChangesAsync();
        return base.Ok(Envelope.Success());
    }

    protected async Task<IActionResult> Success<T>(T result)
    {
        await _unitOfWork.SaveChangesAsync();
        return base.Ok(Envelope.Success(result));
    }

    protected IActionResult Error(string errorMessage)
    {
        return BadRequest(Envelope.Error(errorMessage));
    }
}