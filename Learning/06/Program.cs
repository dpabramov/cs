using System;

namespace _03
{
    class Program
    {

        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите строку:");
            do
            {
                string inputedString = Console.ReadLine();
                int stringLength = inputedString.Length;

                if (inputedString == "exit")
                    break;

                if (stringLength > 15)
                {
                    Console.WriteLine($"Длина строки {inputedString} слишком большая. Повторите попытку");
                    continue;
                }

                Console.WriteLine($"Длина строки {inputedString} составляет {stringLength}");
            } while (true);
        }
    }
}
