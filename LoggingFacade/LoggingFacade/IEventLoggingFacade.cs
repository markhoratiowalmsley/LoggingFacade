using System;

namespace LoggingFacade
{
    public interface IEventLoggingFacade<out TCategory>
    {
        void LogCritical(EventLog eventLog);
        void LogDebug(EventLog eventLog);
        void LogError(EventLog eventLog);
        void LogInformation(EventLog eventLog);
        void LogWarning(EventLog eventLog);
        IDisposable BeginScope<TState>(TState state);
    }
}