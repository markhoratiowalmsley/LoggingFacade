using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggingFacade;
using Microsoft.Extensions.Logging;

namespace LoggingFacadeDemo
{
    public static class Events
    {

        public static EventLog Information => new EventLog
        {
            EventId = new EventId(1, "Information"),
            Message = "Information"
        };

        public static EventLog Error => new EventLog
        {
            EventId = new EventId(2, "Error"),
            Message = "Error",
            Exception = new StackOverflowException("Hehehe")
        };

        public static EventLog Critical => new EventLog
        {
            EventId = new EventId(3, "Critical"),
            Message = "Critical",
            Exception = new OutOfMemoryException("Oh dear")
        };

        public static EventLog Warning => new EventLog
        {
            EventId = new EventId(4, "Warning"),
            Message = "Warning"
        };

        public static EventLog Debug => new EventLog
        {
            EventId = new EventId(5, "Debug"),
            Message = "Debug",
        };
    }
}
