using System;
using System.Collections.Generic;

namespace FileAndConsolLogWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConsoleLogWriter consoleLogWriter = new ConsoleLogWriter();
            //FileLogWriter fileLogWriter = new FileLogWriter("file.log");

            //consoleLogWriter.LogInfo("Успешно");
            //consoleLogWriter.LogWarning("Есть небольшой косячок");
            //consoleLogWriter.LogError("Ошибка");

            //fileLogWriter.LogInfo("Успешно");
            //fileLogWriter.LogWarning("Есть небольшой косячок");
            //fileLogWriter.LogError("Ошибка");

            ConsoleLogWriter consoleLogWriter = new ConsoleLogWriter();
            FileLogWriter fileLogWriter = new FileLogWriter("file11.log");
            FileLogWriter fileLogWriter2 = new FileLogWriter("file22.log");
            List<ILogWriter> logWriters = new List<ILogWriter>
            {
                consoleLogWriter,
                fileLogWriter,
                fileLogWriter2
            };

            MultiLogWriter multiLogWriters = new MultiLogWriter(logWriters);

            multiLogWriters.LogInfo("Это просто снова info пипец");
            multiLogWriters.LogWarning("Это просто снова warning пипец");
            multiLogWriters.LogError("Это просто снова Error пипец");


            Console.ReadKey();
        }
    }
}
