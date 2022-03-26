using System;

namespace _051
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Введите число: ");
            //int age = int.Parse(Console.ReadLine());

            for (int age = 1; age <= 100; age++)
            {
                if ((age >= 5 && age <= 20)
                    || age % 10 == 0
                    || age % 10 == 5
                    || age % 10 == 6
                    || age % 10 == 7
                    || age % 10 == 8
                    || age % 10 == 9)
                    Console.WriteLine($"{age} лет");
                else if (age % 10 == 1)
                    Console.WriteLine($"{age} год");
                else if (age % 10 == 2
                    || age % 10 == 3
                    || age % 10 == 4)
                    Console.WriteLine($"{age} года");
                else
                    Console.WriteLine($"!!!!!!!!!!!!Сбой!!!!!!!!!!!!!!!!!!!1");
            }

            Console.ReadKey();
        }
    }
}
