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
            } while (consoleKeyInfo.Key.ToString() == "y" || consoleKeyInfo.Key.ToString() == "Y");
        }
    }
}
