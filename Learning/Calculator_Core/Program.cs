using System;
using static BaseCalculations.SimpleCalculations;
using static BaseCalculations.Types;


namespace Calculator_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                double val1 = GetValueFromConsole();
                double val2 = GetValueFromConsole();
                TypeOperation typeOperation = GetTypeOperation();
                Calculate(val1, val2, typeOperation);
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
    }
}
