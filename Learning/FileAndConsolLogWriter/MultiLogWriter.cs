using System;
using System.Collections.Generic;
using System.Text;

namespace FileAndConsolLogWriter
{
    class MultiLogWriter : ILogWriter
    {
        private List<ILogWriter> _logWriters;

        public MultiLogWriter(List<ILogWriter> logWriters)
        {
            _logWriters = logWriters;
        }

        public void LogError(string message)
        {
            foreach (ILogWriter il in _logWriters)
            {
                il.LogError(message);
            }

            //_logWriters.ForEach
        }

        public void LogInfo(string message)
        {
            foreach (ILogWriter il in _logWriters)
            {
                il.LogInfo(message);
            }
        }

        public void LogWarning(string message)
        {
            foreach (ILogWriter il in _logWriters)
            {
                il.LogWarning(message);
            }
        }
    }
}
