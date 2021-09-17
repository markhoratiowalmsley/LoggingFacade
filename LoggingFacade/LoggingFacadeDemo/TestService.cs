using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggingFacade;

namespace LoggingFacadeDemo
{
    public class TestService : ITestService
    {
        private readonly IEventLoggingFacade<TestService> _logging;

        public TestService(IEventLoggingFacade<TestService> logging)
        {
            _logging = logging;
        }

        public void DoTheStuff()
        {
            _logging.LogInformation(Events.Information);
            _logging.LogDebug(Events.Debug);
            _logging.LogCritical(Events.Critical);
            _logging.LogWarning(Events.Warning);
            _logging.LogError(Events.Error);
        }
    }
}
