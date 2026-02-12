namespace LIBRARY.Logging;

public class Logger(ILogger logger)
{
    private ILogger _logger = logger;

    public void Logging(string logMessage)
    {
        _logger.Log(logMessage);
    }
}