using System;

namespace _072_DirtyString
{
    class Program
    {
        static void Main(string[] args)
        {
            //убрать лишние пробелы
            //поднять регистр всех букв второго слова
            string inputString = "     lorem   ipsum   dolor        sit    amet    ";
            string result = string.Empty;

            string[] words = inputString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            words[1] = words[1].ToUpper();

            result = string.Join(' ', words);

            Console.WriteLine(inputString);
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
