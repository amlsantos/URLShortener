namespace Infrastructure.Loggers;

public class WatchdogOptions
{
    public const string Watchdog = nameof(Watchdog);
    public const string DefaultConnection = nameof(DefaultConnection);
    public string PageUsername { get; set; }
    public string PagePassword { get; set; }
}