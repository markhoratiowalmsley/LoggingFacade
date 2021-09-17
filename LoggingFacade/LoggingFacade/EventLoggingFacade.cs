using System;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace LoggingFacade
{
    public class EventLoggingFacade<TCategory> : IEventLoggingFacade<TCategory>
    {
        private readonly ILogger<TCategory> _logger;

        public EventLoggingFacade(
            ILogger<TCategory> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void LogCritical(EventLog eventLog)
        {
            ExceptionGuard(eventLog);
            DefaultGuard(eventLog);

            _logger.LogCritical(
                eventLog.EventId, 
                eventLog.Exception, 
                eventLog.Message);
        }

        public void LogDebug(EventLog eventLog)
        {
            DefaultGuard(eventLog);

            _logger.LogDebug(
                eventLog.EventId,
                eventLog.Message);
        }

        public void LogError(EventLog eventLog)
        {
            ExceptionGuard(eventLog);
            DefaultGuard(eventLog);

            _logger.LogError(
                eventLog.EventId, 
                eventLog.Exception, 
                eventLog.Message);
        }

        public void LogInformation(EventLog eventLog)
        {
            DefaultGuard(eventLog);

            _logger.LogInformation(
                eventLog.EventId,
                eventLog.Message);
        }

        public void LogWarning(EventLog eventLog)
        {
            DefaultGuard(eventLog);
            
            _logger.LogWarning(
                eventLog.EventId,
                eventLog.Message);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return _logger.BeginScope(state);
        }

        private static void ExceptionGuard(EventLog eventLog, [CallerMemberName]string method = "")
        {
            if (eventLog.Exception == null)
            {
                throw new ArgumentException(
                    $"An EventLog in {method} must contain an Exception",
                    nameof(eventLog));
            }
        }

        private static void DefaultGuard(EventLog eventLog)
        {
            if (eventLog.EventId == default
                || eventLog.Message == default)
            {
                throw new ArgumentException($"An EventLog must always an eventId and message");
            }
        }
    }
}