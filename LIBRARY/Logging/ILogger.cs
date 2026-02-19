namespace LIBRARY.Logging;

public interface ILogger
{
    public void InfoLogger(string logMessage);
    public void DebugLogger(string logMessage);
    public void WarnLogger(string logMessage);
    public void ErrorLogger(string logMessage);
    public void FatalLogger(string logMessage);
}