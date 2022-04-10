using System;
using System.Collections.Generic;
using System.Text;

namespace FileAndConsolLogWriter
{
    class MultiLogWriter : ILogWriter
    {
        //реализуем синглтон
        private static MultiLogWriter _multiLogWriter;

        //реализуем синглтон
        public static MultiLogWriter GetInstance(List<ILogWriter> logWriters)
        {
            if (_multiLogWriter == null)
                _multiLogWriter = new MultiLogWriter();

            _multiLogWriter._logWriters = logWriters;
            return _multiLogWriter;

        }

        private List<ILogWriter> _logWriters;

        //реализуем синглтон
        private MultiLogWriter()
        {
        }

        //реализуем синглтон
        //public MultiLogWriter(List<ILogWriter> logWriters)
        //{
        //    _logWriters = logWriters;
        //}

        public void LogError(string message)
        {
            _logWriters.ForEach(delegate (ILogWriter writer) { writer.LogError(message); });
        }

        public void LogInfo(string message)
        {
            _logWriters.ForEach(delegate (ILogWriter writer) { writer.LogInfo(message); });
        }

        public void LogWarning(string message)
        {
            _logWriters.ForEach(delegate (ILogWriter writer) { writer.LogWarning(message); });
        }
    }
}
