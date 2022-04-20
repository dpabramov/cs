using System;

namespace _17_EventsExample5
{
    class Program
    {
        static void Main(string[] args)
        {
            Traveler traveler = new Traveler();

            traveler.DistantPerformed += OnDistantPerformed;

            traveler.DistantCompleted += OnDistantCompleted;

            traveler.DistantStarted += OnDistantStarted;

            traveler.Go(100, 25);

            Console.ReadKey();
        }

        private static void OnDistantPerformed(object sender, DistantPerformedEventArgs e)
        {
            Console.WriteLine($"Пройдено {e.Curent} из {e.Total} километров пути. Осталось {e.Rest}км.");
        }

        private static void OnDistantStarted(object sender, DistantCompletedEventArgs e)
        {
            Console.WriteLine($"Движение длиной {e.total} км началось.");
        }

        private static void OnDistantCompleted(object sender, DistantCompletedEventArgs e)
        {
            Console.WriteLine($"Пройден путь длиной {e.total} км.");
        }
    }
}
