namespace LIBRARY.BookFolder;

public class ConsoleLogger : ILogger
{
    public void Log(string logMessage)
    {
        Console.WriteLine(logMessage);
    }
}