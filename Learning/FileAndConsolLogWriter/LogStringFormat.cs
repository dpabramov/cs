using System;
using System.Collections.Generic;
using System.Text;

namespace FileAndConsolLogWriter
{
    public abstract class LogWriter : ILogWriter
    {
        protected string StrFormat { get; set; } = "{0:dd-MM-yyyy HH:mm:ss.fff}\t{1}\t{2}";

        protected string GetLogString(MessageType messageType, string message)
        {
            return string.Format(StrFormat, 
                DateTimeOffset.Now,
                messageType, 
                message);
        }

        public void LogError(string message)
        {
            WriteSingleRecord(GetLogString(MessageType.Error, message));
        }

        public void LogInfo(string message)
        {
            WriteSingleRecord(GetLogString(MessageType.Info, message));
        }

        public void LogWarning(string message)
        {
            WriteSingleRecord(GetLogString(MessageType.Warning, message));
        }

        public abstract void WriteSingleRecord(string message);

    }
}
