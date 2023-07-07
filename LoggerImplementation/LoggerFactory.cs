using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NLog;
using NLog.Web;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LoggerImplementation;

public class LoggerFactory : ILogger
{
    private readonly IConfiguration _configuration;

    private protected readonly ILogger _logger;

    public LoggerFactory(IConfiguration configuration)
    {
        _configuration = configuration;
        var loggingSettings = _configuration.GetSection("LoggerType").Value;
        _ = Enum.TryParse(loggingSettings, out LoggerType loggerType);
        var writePath = _configuration.GetSection("Serilog:WriteTo")
            .GetSection("File")
            .GetValue<string>("Args:path")?? "/logs/log-.txt";
        switch (loggerType)
        {
            case LoggerType.NLog:
                _logger = new NLogLogger();
                break;
            case LoggerType.Serilog:
                _logger = new SerilogLogger(writePath);
                break;
            case LoggerType.Log4Net:
                break;
            default:
                throw new ArgumentException("Invalid logger type specified in the settings.");
        }
    }

    public void LogError(Exception ex, string message)
    {
        _logger.LogError(ex, message);
    }

    public void LogInformation(string message)
    {
        _logger.LogInformation(message);
    }

    public void LogWarning(string message)
    {
        _logger.LogWarning(message);
    }
}
