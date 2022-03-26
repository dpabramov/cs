using System;

namespace _054
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число меньше 100:");
            int value;

            if(!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Введено не число. " +
                    "\nНажмите любую клавишу для завершения работы.");
                Console.ReadKey();

                Environment.Exit(1);
            }
             
            if(value >= 100 || value < 0)
            {
                throw new ArgumentOutOfRangeException("Число не в диапазоне   0 < a < 100");
            }

            Console.WriteLine($"Введенное число {value} соответствует условию < 100");
            Console.ReadKey();
       }
    }
}
