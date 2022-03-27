using System;
using System.Collections.Generic;

namespace _081_ListExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            const string stop = "stop";
            List<double> inputList = new List<double>();
            Console.WriteLine("Введите значение типа double:");
            double avgValue;
            double summaValue = 0;

            do
            {
                string inputString = String.Empty;
                double inputDouble = 0;
                inputString = Console.ReadLine();

                if (inputString.ToLower() == stop)
                    break;

                try
                {
                    inputDouble = double.Parse(inputString);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Работа программа будет завершена...");
                    Console.ReadKey();
                    return;
                }

                inputList.Add(inputDouble);

            } while (true);

            foreach (double db in inputList)
            {
                summaValue += db;
            }

            avgValue = summaValue / inputList.Count;

            Console.WriteLine($"Сумма введенных значений {summaValue}, " +
                $"\nа среднее арифметическое {avgValue:0.000}.");

            Console.ReadKey();
        }
    }
}
