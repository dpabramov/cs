using System;

namespace _052_ternar_operator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число меньше 100: ");
            int value;
            if (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Проблемы с введенным числом...");
                Environment.Exit(1);
            }

            //используем тернарный оператор
            string result = value <= 50
                ? $"Число {value} < 50"
                : $"Число {value} > 50";
            Console.WriteLine(result);

            //или тот же вывод без переменной
            Console.WriteLine(value <= 50
            ? $"Число {value} < 50"
            : $"Число {value} > 50");

            Console.ReadKey();
        }

    }
}

