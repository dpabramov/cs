using System;

namespace DI_example
{
    class Logger
    {
        private ILogger _logService;

        public Logger(ILogger logService)
        {
            _logService = logService;
        }

        public void Log(string message) => _logService.Write($"{DateTime.Now}  {message}");
    }
}
