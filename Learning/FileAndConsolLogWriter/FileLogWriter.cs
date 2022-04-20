using FileAndConsolLogWriter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileAndConsolLogWriter
{
    class FileLogWriter : LogWriter, IDisposable
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
            byte[] arr = Encoding.UTF8.GetBytes(message + "\n");

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

        //можно записывать в файл другим потоком...
        private void WriteToFile2(string message)
        {
            using (StreamWriter sw = new StreamWriter(File.Open(_fileName,
                FileMode.Append, 
                FileAccess.Write,
                FileShare.Read)
                ))
            {
                sw.WriteLine(message);
            }
        }

        public void Dispose()
        {
            _fileStream.Close();
        }

        public override void WriteSingleRecord(string message)
        {
            //можно использовать WriteToFile или WriteToFile2
            WriteToFile2(message);
        }
    }
}
