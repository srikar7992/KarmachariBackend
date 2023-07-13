using Microsoft.Extensions.Logging;

namespace LoggerImplementation;

public class LoggingSettings
{
    public LogLevel LogLevel { get; set; }
    public string LogFilePath { get; set; } = string.Empty;
    public LoggerType LoggerType { get; set; }
}
