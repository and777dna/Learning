namespace LIBRARY.BookFolder;

public class Logger(ILogger logger)
{
    private ILogger _logger = logger;

    public void Logging(string logMessage)
    {
        logger.Log(logMessage);
    }
}