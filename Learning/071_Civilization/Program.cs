using System;

namespace _071_Civilization
{
    class Program
    {
        static void Main(string[] args)
        {
            int index;
            int pos = -1;
            string result = string.Empty;
            Console.WriteLine("Введите строку: ");
            string inputString = Console.ReadLine();

            Console.Write("Введите символ для поиска: ");
            char inputChar = Console.ReadKey().KeyChar;

            do
            {
                index = inputString.IndexOf(inputChar, pos + 1);
                if (index != -1)
                {
                    result += index + " ";
                    pos = index;
                }
                else
                    break;
            } while (true);

            Console.WriteLine($"\nИндексы вхождения: {result}");
            Console.ReadKey();
        }
    }
}
