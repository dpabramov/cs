using System;
using System.Collections.Generic;
using System.Text;

namespace FileAndConsolLogWriter
{
    public class ConsoleLogWriter : ILogWriter
    {
        public void LogError(string message)
        {
            Console.WriteLine(LogStringFormat.GetLogString(MessageType.Error, message));
        }

        public void LogInfo(string message)
        {
            Console.WriteLine(LogStringFormat.GetLogString(MessageType.Info, message));
        }

        public void LogWarning(string message)
        {
            Console.WriteLine(LogStringFormat.GetLogString(MessageType.Warning, message));
        }
    }
}
