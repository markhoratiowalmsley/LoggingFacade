using System;
using Microsoft.Extensions.Logging;

namespace LoggingFacade
{
    public class EventLog
    {
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public EventId EventId { get; set; }
    }
}
