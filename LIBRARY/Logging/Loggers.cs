namespace LIBRARY.Logging;


/*public class Loggers : ILogger
{
    public void LogInformation(string logMessage)
    {
        Console.WriteLine(logMessage);
    }
}*/

public class DebugLogger : ILogger
{
    public void Log(string logMessage)
    {
        Console.WriteLine(logMessage);
    }
}

public class InfoLogger : ILogger
{
    public void Log(string logMessage)
    {
        Console.WriteLine(logMessage);
    }
}

public class WarnLogger : ILogger
{
    public void Log(string logMessage)
    {
        Console.WriteLine(logMessage);
    }
}

public class ErrorLogger : ILogger
{
    public void Log(string logMessage)
    {
        Console.WriteLine(logMessage);
    }
}

public class FatalLogger : ILogger
{
    public void Log(string logMessage)
    {
        Console.WriteLine(logMessage);
    }
}