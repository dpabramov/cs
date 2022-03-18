using System;

namespace _031
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число:");
            int summa = 0;
            int count = 0;
            while (count < 5)
            {
                try
                {
                    var inputedValue = int.Parse(Console.ReadLine());
                    summa += inputedValue;
                    count++;
                }
                catch
                {
                    Console.WriteLine("Введено не целое число, повторите попытку");
                    continue;
                }
            }
            Console.WriteLine($"Сумма введенных чисел составляет {summa}");
            Console.ReadKey();
        }
    }
}
