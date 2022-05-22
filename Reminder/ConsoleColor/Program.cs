using System;

namespace ConsoleColor
{
    class Program
    {
        static void Main(string[] args)
        {
            var remember = Console.ForegroundColor; //= ConsoleColor.Red;
            Console.ForegroundColor = System.ConsoleColor.Red;
            Console.WriteLine("Hello World!");
            Console.ForegroundColor = remember;
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
