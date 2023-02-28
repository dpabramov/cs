using System;
using System.Collections.Generic;
using System.Text;

namespace DI_example
{
    class SimpleLogServiceGreen : ILogger
    {
        public void Write(string message)
        {
            var color = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(message);

            Console.ForegroundColor = color;
        }
    }
}
