using System;

namespace _034
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();

            do
            {
                Console.WriteLine("Введите натуральное число:");
                string inputString = Console.ReadLine();
                int total = 0;

                try
                {
                    int value = int.Parse(inputString);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено не число, повторите попытку...");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Введено слишком большое число, повторите попытку...");
                    continue;
                }

                foreach (char val in inputString)
                {
                    if ((int)val % 2 == 0)
                        total += 1;
                }

                Console.WriteLine($"В натуральном числе {inputString} содержится {total} четных цифр.");
                Console.WriteLine("Для продолжения нажмите любую клавишу. \nДля завершения нажмите ESC...");
                cki = Console.ReadKey();
                Console.WriteLine("\n");
            } while (cki.Key != ConsoleKey.Escape);
        }
    }
}
