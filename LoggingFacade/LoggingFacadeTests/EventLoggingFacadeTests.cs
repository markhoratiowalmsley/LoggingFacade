using System;
using LoggingFacade;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace LoggingFacadeTests
{
    [TestClass]
    public class EventLoggingFacadeTests
    {
        private EventLoggingFacade<EventLoggingFacadeTests> _facade;

        [SetUp]
        public void SetUp()
        {
            var logger = new Mock<ILogger<EventLoggingFacadeTests>>();
            _facade = new EventLoggingFacade<EventLoggingFacadeTests>(logger.Object);
        }

        [Test]
        public void LogCritical_DoesNotThrow_EventLogSet()
        {
            Assert.DoesNotThrow(() => _facade.LogCritical(
                new EventLog
                {
                    Exception = new ArgumentNullException(),
                    EventId = new EventId(1),
                    Message = "Test"
                }));
        }

        [Test]
        public void LogCritical_ThrowsArgumentException_ExceptionNotSet()
        {
            Assert.Throws<ArgumentException>(() => _facade.LogCritical(
                new EventLog
                {
                    EventId = new EventId(1),
                    Message = "Test"
                }));
        }

        [Test]
        public void LogCritical_ThrowsArgumentException_DefaultsNotSet()
        {
            Assert.Throws<ArgumentException>(() => _facade.LogCritical(
                new EventLog
                {
                    Exception = new ArgumentNullException()
                }));
        }

        [Test]
        public void LogError_DoesNotThrow_EventLogSet()
        {
            Assert.DoesNotThrow(() => _facade.LogError(
                new EventLog
                {
                    Exception = new ArgumentNullException(),
                    EventId = new EventId(1),
                    Message = "Test"
                }));
        }

        [Test]
        public void LogError_ThrowsArgumentException_ExceptionNotSet()
        {
            Assert.Throws<ArgumentException>(() => _facade.LogError(
                new EventLog
                {
                    EventId = new EventId(1),
                    Message = "Test"
                }));
        }

        [Test]
        public void LogError_ThrowsArgumentException_DefaultsNotSet()
        {
            Assert.Throws<ArgumentException>(() => _facade.LogError(
                new EventLog
                {
                    Exception = new ArgumentNullException()
                }));
        }

        [Test]
        public void LogWarning_DoesNotThrow_EventLogSet()
        {
            Assert.DoesNotThrow(() => _facade.LogWarning(
                new EventLog
                {
                    EventId = new EventId(1),
                    Message = "Test"
                }));
        }


        [Test]
        public void LogWarning_ThrowsArgumentException_DefaultsNotSet()
        {
            Assert.Throws<ArgumentException>(() => _facade.LogWarning(
                new EventLog
                {
                    Exception = new ArgumentNullException()
                }));
        }

        [Test]
        public void LogDebug_DoesNotThrow_EventLogSet()
        {
            Assert.DoesNotThrow(() => _facade.LogWarning(
                new EventLog
                {
                    EventId = new EventId(1),
                    Message = "Test"
                }));
        }


        [Test]
        public void LogDebug_ThrowsArgumentException_DefaultsNotSet()
        {
            Assert.Throws<ArgumentException>(() => _facade.LogWarning(
                new EventLog
                {
                    Exception = new ArgumentNullException()
                }));
        }

        [Test]
        public void LogInformation_DoesNotThrow_EventLogSet()
        {
            Assert.DoesNotThrow(() => _facade.LogInformation(
                new EventLog
                {
                    EventId = new EventId(1),
                    Message = "Test"
                }));
        }


        [Test]
        public void LogInformation_ThrowsArgumentException_DefaultsNotSet()
        {
            Assert.Throws<ArgumentException>(() => _facade.LogWarning(
                new EventLog
                {
                    Exception = new ArgumentNullException()
                }));
        }
    }
}
