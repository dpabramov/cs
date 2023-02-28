using System;

namespace DI_example
{
    class SimpleLogService : ILogger
    {
        public void Write(string message) => Console.WriteLine(message);
    }
}
