using Application.Interfaces;
using WatchDog;

namespace Infrastructure.Loggers;

public class WatchDogLogger : IConsoleLogger
{
    private readonly IConsoleLogger _consoleLogger;
    public WatchDogLogger(IConsoleLogger consoleLogger) => _consoleLogger = consoleLogger;

    public void LogInformation(string message)
    {
        WatchLogger.Log(message);
        _consoleLogger.LogInformation(message);
    }

    public void LogError(string message)
    {
        WatchLogger.LogError(message);
        _consoleLogger.LogError(message);
    }

    public void LogError(Exception exception, string message)
    {
        WatchLogger.LogError(message);
        _consoleLogger.LogError(exception, message);
    }

    public void LogWarning(string message)
    {
        WatchLogger.LogWarning(message);
        _consoleLogger.LogWarning(message);
    }
}