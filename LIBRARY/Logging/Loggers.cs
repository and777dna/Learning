namespace LIBRARY.Logging;

public class Logger : ILogger
{
    public void InfoLogger(string logMessage)
    {
        Console.WriteLine(logMessage);
    }

    public void DebugLogger(string logMessage)
    {
        Console.WriteLine(logMessage);
    }
    public void WarnLogger(string logMessage)
    {
        Console.WriteLine(logMessage);
    }
    public void ErrorLogger(string logMessage)
    {
        Console.WriteLine(logMessage);
    }
    public void FatalLogger(string logMessage)
    {
        Console.WriteLine(logMessage);
    }
}