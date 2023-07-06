﻿namespace LoggerImplementation;

public interface ILogger
{
    void LogInformation(string message);
    void LogWarning(string message);
    void LogError(Exception ex, string message);
}