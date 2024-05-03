using Microsoft.Extensions.Logging;

namespace Mocks;

public class MockLogger<T> : ILogger<T>
{
    public List<EventId> LogErrors { get; set; } = new List<EventId>();
    public List<EventId> LogInformations { get; set; } = new List<EventId>();

    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state,
        Exception exception, Func<TState, Exception, string> formatter)
    {
        switch (logLevel)
        {
            case LogLevel.Information:
                LogInformations.Add(eventId);
                break;
            case LogLevel.Error:
                LogErrors.Add(eventId);
                break;
        }
    }
}
