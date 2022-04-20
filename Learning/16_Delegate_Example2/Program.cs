using System;

namespace _16_Delegate_Example2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new[] { 1, 3, 5, 7, 9 };

            doCalculationAndWriteConsole(array, Summ, "Сумма");

            doCalculationAndWriteConsole(array, Average, "Среднее значение");

            Console.ReadKey();
        }

        static int Summ(int[] array)
        {
            int result = 0;
            foreach (var arr in array)
            {
                result += arr;
            }
            return result;
        }
        
        static int Average(int[] array)
        {
            int summ = Summ(array);
            return summ / array.Length;
        }

        static void doCalculationAndWriteConsole(int[] array, 
            Func<int[], int> doCalculation, 
            string calculationName)
        {
            int result = doCalculation(array);

            Console.WriteLine($"{calculationName}: {result}");
        }

        //delegate int DoCalculation(int[] array);
    }
}
