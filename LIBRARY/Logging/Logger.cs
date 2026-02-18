namespace LIBRARY.Logging;

public class Logger(ILogger logger)
{
    //private string _path = path;
    //path1, path2, path3=>to create switch()case()
    //
    private ILogger _logger = logger;

    public void Logging(string logMessage)
    {
        _logger.Log(logMessage);
    }
    
    public void Error(string logMessage)
    {
        _logger.Log(logMessage);
    }
}