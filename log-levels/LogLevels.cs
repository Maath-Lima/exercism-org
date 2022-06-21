using System;

static class LogLine
{
    public static string Message(string logLine) => logLine.Split(':')[1].Trim();
   
    public static string LogLevel(string logLine)
    {
        var log = logLine.Split(':')[0];

        return log.Substring(1, log.Length - 2).ToLower();
    }

    public static string Reformat(string logLine) => $"{LogLine.Message(logLine)} ({LogLine.LogLevel(logLine)})";
}
