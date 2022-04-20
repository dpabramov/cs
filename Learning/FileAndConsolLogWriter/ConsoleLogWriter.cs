using System;
using System.Collections.Generic;
using System.Text;

namespace FileAndConsolLogWriter
{
    public class ConsoleLogWriter : LogWriter
    {
        public override void WriteSingleRecord(string message)
        {
            Console.WriteLine(message);
        }
    }
}
