using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _131_Dispose
{
    class FileWriter : IDisposable
    {
        string _fileName;

        FileStream _fileStream;

        public FileWriter(string filename)
        {
            _fileName = filename;
        }

        public void CreateNewFile()
        {
            _fileStream = new FileStream(_fileName,
                FileMode.Create,
                FileAccess.Write,
                FileShare.Read);
        }

        public void OpenExistingFile()
        {
            _fileStream = new FileStream(_fileName,
                FileMode.Append,
                FileAccess.Write,
                FileShare.None);
        }

        public void Dispose()
        {
            _fileStream.Close();
        }

        public void WriteToFile(string text)
        {
            byte[] array = Encoding.UTF8.GetBytes(text);
            _fileStream.Write(array);
        }
    }
}
