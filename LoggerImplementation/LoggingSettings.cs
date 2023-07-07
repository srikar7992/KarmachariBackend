using Microsoft.Extensions.Logging;

namespace LoggerImplementation;

public class LoggingSettings
{
    public LogLevel LogLevel { get; set; }
    public string LogFilePath { get; set; }
    public LoggerType LoggerType { get; set; }
}
