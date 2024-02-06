using System.Diagnostics;
using System.Text.Json;
using Application.Interfaces;
using CSharpFunctionalExtensions;
using MediatR;

namespace Infrastructure.Behaviours;

public sealed class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class, IRequest<TResponse>
{
    private readonly IConsoleLogger _logger;
    
    public LoggingBehavior(IConsoleLogger logger) => _logger = logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = request.GetType().Name;
        var requestGuid = Guid.NewGuid().ToString();
        var requestNameWithGuid = $"{requestName} [{requestGuid}]";
        var stopwatch = Stopwatch.StartNew();
        
        TResponse response = default!;

        try
        {
            _logger.LogInformation($"[START] {requestNameWithGuid} {JsonSerializer.Serialize(request)}");
            response = await next();
        }
        catch (Exception ex)
        {
            _logger.LogWarning($"[ERROR] {requestNameWithGuid} Error while executing a handler. Error: {ex.Message}");
        }
        finally
        {
            if (HasResult(response)) 
                ShowResult(response, stopwatch, requestNameWithGuid);
            
            stopwatch.Stop();
        }

        return response;
    }

    private bool HasResult(TResponse? response)
    {
        return response?.GetType().Name.Contains(nameof(Result)) ?? false;
    }

    private void ShowResult(TResponse? response, Stopwatch stopwatch, string requestNameWithGuid)
    {
        var result = response ?? Result.Failure<object>("error while converting response to Result object");

        if (result.IsSuccess)
            ShowSuccessResponse(result, stopwatch, requestNameWithGuid);
        else if (result.IsFailure)
            ShowErrorResponse(result, stopwatch, requestNameWithGuid);
    }

    private void ShowSuccessResponse(Result<object> result, Stopwatch stopwatch, string requestNameWithGuid)
    {
        _logger.LogInformation($"[RESPONSE] [SUCCESS] {requestNameWithGuid}; Result={result.Value};");
        _logger.LogInformation($"[RESPONSE] [TIME] {requestNameWithGuid}; Execution time={stopwatch.ElapsedMilliseconds}ms");
    }

    private void ShowErrorResponse(Result<object> result, Stopwatch stopwatch, string requestNameWithGuid)
    {
        _logger.LogError($"[RESPONSE] [ERROR] {requestNameWithGuid}; Error={result.Error};");
        _logger.LogError($"[RESPONSE] [TIME] {requestNameWithGuid}; Execution time={stopwatch.ElapsedMilliseconds}ms");
    }
}