using System;

namespace _17_EventsExample2
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();

            reader.ReadStarted += OnReadStarted;

            reader.PartReadFinished += OnPartReadFinished;

            reader.ReadFinished += OnReadFinished;

            reader.ToRead();

            Console.ReadKey();
        }

        private static void OnReadFinished(object sender, EventArgs e)
        {
            Console.WriteLine("Прочитано...");
        }

        private static void OnPartReadFinished(int propcent)
        {
            Console.WriteLine($"Выполнено {propcent}%");
        }

        private static void OnReadStarted(object sender, EventArgs e)
        {
            Console.WriteLine("Поехали...");
        }
    }
}
