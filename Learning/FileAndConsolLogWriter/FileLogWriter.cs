using FileAndConsolLogWriter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileAndConsolLogWriter
{
    class FileLogWriter : ILogWriter, IDisposable
    {
        //реализуем синглтон
        private static FileLogWriter _fileLogWriter;

        //реализуем синглтон
        public static FileLogWriter GetInstance(string fileName)
        {
            if (_fileLogWriter == null)
            {
                _fileLogWriter = new FileLogWriter();
                _fileLogWriter._fileName = fileName;
            };

            return _fileLogWriter;
        }

        private string _fileName;

        private FileStream _fileStream;

        //реализуем синглтон
        //public FileLogWriter(string fileName)
        //{
        //    _fileName = fileName;
        //}

        //реализуем синглтон
        private FileLogWriter()
        {
        }



        private void WriteToFile(string message)
        {
            //массив для записи в файл
            byte[] arr = Encoding.UTF8.GetBytes(message);

            //создаем или открываем файл
            using (_fileStream = new FileStream(_fileName,
                FileMode.OpenOrCreate,
                FileAccess.Write,
                FileShare.Read))
            {
                //перемещаемся в конец файла
                _fileStream.Seek(0, SeekOrigin.End);

                //пишем в файл
                _fileStream.Write(arr);
            }
        }

        public void LogError(string message)
        {
            string m = LogStringFormat.GetLogString(MessageType.Error, message) + "\n";
            WriteToFile(m);
        }

        public void LogInfo(string message)
        {
            string m = LogStringFormat.GetLogString(MessageType.Info, message) + "\n";
            WriteToFile(m);
        }

        public void LogWarning(string message)
        {
            string m = LogStringFormat.GetLogString(MessageType.Warning, message) + "\n"; ;
            WriteToFile(m);
        }

        public void Dispose()
        {
            _fileStream.Close();
        }
    }
}
