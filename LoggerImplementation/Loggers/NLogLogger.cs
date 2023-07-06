using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerImplementation;

public class NLogLogger : ILogger
{
    private readonly Logger _logger;

    public NLogLogger()
    {
        _logger = LogManager.GetCurrentClassLogger();
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
