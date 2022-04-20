using System;
using System.Collections.Generic;
using System.Text;

namespace FileAndConsolLogWriter
{
    class MultiLogWriter : LogWriter
    {
        //реализуем синглтон
        private static MultiLogWriter _multiLogWriter;

        //реализуем синглтон
        public static MultiLogWriter GetInstance(List<LogWriter> logWriters)
        {
            if (_multiLogWriter == null)
                _multiLogWriter = new MultiLogWriter();

            _multiLogWriter._logWriters = logWriters;
            return _multiLogWriter;

        }

        private List<LogWriter> _logWriters;

        //реализуем синглтон
        private MultiLogWriter()
        {
        }

        //реализуем синглтон
        //public MultiLogWriter(List<ILogWriter> logWriters)
        //{
        //    _logWriters = logWriters;
        //}

        public override void WriteSingleRecord(string message)
        {
            _logWriters.ForEach(delegate (LogWriter writer)
            {
                writer.WriteSingleRecord(message);
            });
        }
    }
}
