using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            //Запоминаем  введенный символ
            char c = Console.ReadKey(true).KeyChar;

            if (char.IsLetterOrDigit(c))
                Console.WriteLine($"{c} IsLetterOrDigit");
            else if (char.IsPunctuation(c))
                Console.WriteLine($"{c} IsPunctuation");
            else Console.WriteLine($"ХЗЧ");

            Console.ReadKey();
        }
    }
}
