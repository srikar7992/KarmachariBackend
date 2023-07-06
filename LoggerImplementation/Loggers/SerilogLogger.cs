using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;

namespace LoggerImplementation;



public class SerilogLogger : ILogger
{
    private readonly Serilog.ILogger _logger;

    public SerilogLogger()
    {
        _logger = new LoggerConfiguration().CreateLogger();
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

