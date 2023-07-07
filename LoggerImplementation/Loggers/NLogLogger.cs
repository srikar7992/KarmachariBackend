using NLog;
using NLog.Web;

namespace LoggerImplementation;

public class NLogLogger : ILogger
{
    private readonly Logger _logger;

    public NLogLogger()
    {
        _logger = LogManager.Setup()
            .LoadConfigurationFromAppSettings()
            .GetCurrentClassLogger();
    }

    public void LogInformation(string message)
    {
        _logger.Info(message);
    }

    public void LogWarning(string message)
    {
        _logger.Warn(message);
    }

    public void LogError(Exception ex, string message)
    {
        _logger.Error(ex, message);
    }
}
