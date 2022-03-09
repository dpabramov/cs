using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Calculation.SimpleCalculation;
using static Calculation.Types;

namespace ConsoleApp2
{
    partial class Program
    {
        static void Main(string[] args)
        {
            string con;
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
