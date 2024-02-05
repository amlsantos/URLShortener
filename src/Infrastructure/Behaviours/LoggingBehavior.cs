using System.Diagnostics;
using System.Text.Json;
using Application.Interfaces;
using MediatR;

namespace Infrastructure.Behaviours;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class, IRequest<TResponse>
{
    private readonly IConsoleLogger _consoleLogger;
    
    public LoggingBehavior(IConsoleLogger consoleLogger) => _consoleLogger = consoleLogger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = request.GetType().Name;
        var requestGuid = Guid.NewGuid().ToString();
        var requestNameWithGuid = $"{requestName} [{requestGuid}]";
        var stopwatch = Stopwatch.StartNew();
        
        TResponse response = default;

        try
        {
            _consoleLogger.LogInformation($"[START] {requestNameWithGuid} {JsonSerializer.Serialize(request)}");
            response = await next();
        }
        catch (NotSupportedException)
        {
            _consoleLogger.LogWarning($"[Serialization ERROR] {requestNameWithGuid} Could not serialize the request.");
        }
        finally
        {
            _consoleLogger.LogInformation($"[END] {requestNameWithGuid} {JsonSerializer.Serialize(response)}");

            stopwatch.Stop();
        }

        return response;
    }
}