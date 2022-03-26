using System;

namespace _07_string
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("a\tb\nc");
            
            /*
             Чтобы ввести с клавиатуры символ ±
             надо включить NumLock, далее зажать Alt 
             и на цифровой клавиатуре набрать 0177
             */
            string a = "test±";
            //два символа наберем через esc-последовательность \u
            //т.е. введем юникод символа u0065  - e, u00b1 - ±
            string b = "T\u0065st\u00b1";

            Console.WriteLine(a);
            Console.WriteLine(b);

            Console.WriteLine(GetUnikod(a));
            Console.WriteLine(GetUnikod(b));

            Console.WriteLine(a == b);
            Console.WriteLine(a.Equals(b));
            //сравнение без учета больших букв
            Console.WriteLine(a.Equals(b,StringComparison.InvariantCultureIgnoreCase));

            Console.ReadKey();
        }

        static string GetUnikod (string input)
        {
            string result =string.Empty;

            foreach (char ch in input)
            {
                result += (int)(ch) + " ";
            }

            return result;
        }
    }
}
