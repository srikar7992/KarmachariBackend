using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerImplementation;

public class LoggingSettings
{
    public LogLevel LogLevel { get; set; }
    public string LogFilePath { get; set; }
    public LoggerType LoggerType { get; set; }
}
