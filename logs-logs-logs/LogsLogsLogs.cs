using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

// TODO: define the 'LogLevel' enum
enum LogLevel
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42
}

static class LogLine
{
    private static IReadOnlyDictionary<LogLevel, string> LogPatterns = new Dictionary<LogLevel, string>()
    {
        { LogLevel.Unknown, "UNK" },
        { LogLevel.Trace, "TRC" },
        { LogLevel.Debug, "DBG" },
        { LogLevel.Info, "INF" },
        { LogLevel.Warning, "WRN" },
        { LogLevel.Error, "ERR" },
        { LogLevel.Fatal, "FTL" },
    };

    private const string LOG_LEVELS_PATTERN = "(TRC|DBG|INF|WRN|ERR|FTL)";

    public static LogLevel ParseLogLevel(string logLine)
    {
        var logLevel = GetLogLevelFromLogLine(logLine);

        return LogPatterns.FirstOrDefault(l => l.Value.Equals(logLevel)).Key;
    }

    private static string GetLogLevelFromLogLine(string logLine)
    {
        var result = new Regex(LOG_LEVELS_PATTERN).Match(logLine);

        if (!result.Success)
        {
            return "UKN";
        }

        return result.Value;
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        return $"{(int)logLevel}:{message}";
    }
}
