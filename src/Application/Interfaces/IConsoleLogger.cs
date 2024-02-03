namespace Application.Interfaces;

public interface IConsoleLogger
{
    public void LogInformation(string message);
    public void LogError(string message);
    public void LogError(Exception exception, string message);
    public void LogWarning(string message);
}