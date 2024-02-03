using Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Loggers;

public class ConsoleLogger : IConsoleLogger
{
    private readonly ILogger<ConsoleLogger> _logger;
    
    public ConsoleLogger(ILogger<ConsoleLogger> logger) => _logger = logger;

    public void LogInformation(string message)
    {
        _logger.LogInformation(message);
    }

    public void LogError(string message)
    {
        _logger.LogError(message);
    }

    public void LogError(Exception exception, string message)
    {
        _logger.LogError(exception, message);
    }

    public void LogWarning(string message)
    {
        _logger.LogWarning(message);
    }
}