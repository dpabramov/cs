using BaseCalculations;
using System;



namespace Calculator_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                double val1 = GetDoubleValueFromConsol();
                double val2 = GetDoubleValueFromConsol();

                SimpleCalculator.Calculate(SimpleCalculator.Summ, val1, val2, "+");
                SimpleCalculator.Calculate(SimpleCalculator.Minus, val1, val2, "-");
                SimpleCalculator.Calculate(SimpleCalculator.Multiply, val1, val2, "*");
                SimpleCalculator.Calculate(SimpleCalculator.Devide, val1, val2, "/");
                SimpleCalculator.Calculate((x, y) => Math.Pow(x, y), val1, val2, "pow");

                Console.Write("Продолжить (Y/N)? ");
                consoleKeyInfo = Console.ReadKey();
                Console.WriteLine("\n");
            }
            //consoleKeyInfo.Key - это именно нажатая клавиша, а не символ
            //и не важно в какой раскладке и на каком языке
            //ConsoleKey.Y  - это сама клавиша Y, т.е. делаем так:
            //consoleKeyInfo.Key.Equals(ConsoleKey.Y)
            //а если нужно сравнить  именно символы, тогда так:
            //consoleKeyInfo.KeyChar.Equals('y')
            while (consoleKeyInfo.Key.Equals(ConsoleKey.Y));
        }

        static double GetDoubleValueFromConsol()
        {
            Console.Write("введите число: ");
            return Double.Parse(Console.ReadLine());
        }

        //static double Pow(double a, double b)
        //{
        //    return Math.Pow(a, b);
        //}
    }
}
