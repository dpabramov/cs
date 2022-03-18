using System;

namespace _032
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[5];
            Console.WriteLine("Введите 5 элементов массива:");
            for(int i=0; i< numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Для завершения работы нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
