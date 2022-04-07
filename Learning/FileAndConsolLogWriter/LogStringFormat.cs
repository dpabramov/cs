using System;
using System.Collections.Generic;
using System.Text;

namespace FileAndConsolLogWriter
{
    public static class LogStringFormat
    {
        public static string GetLogString(MessageType messageType, string message)
        {
            return string.Format("{0:dd-MM-yyyy HH:mm:ss.fff}\t{1}\t{2}", 
                DateTimeOffset.Now,
                messageType, 
                message);
        }
    }
}
