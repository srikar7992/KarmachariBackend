using Serilog;

namespace LoggerImplementation;



public class SerilogLogger : ILogger
{
    private readonly Serilog.ILogger _logger;

    public SerilogLogger(string path)
    {
        _logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(path, rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }

    public void LogInformation(string message)
    {
        _logger.Information(message);
    }

    public void LogWarning(string message)
    {
        _logger.Warning(message);
    }

    public void LogError(Exception ex, string message)
    {
        _logger.Error(ex, message);
    }
}

