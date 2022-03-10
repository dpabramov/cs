using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Calculation.Types;

namespace Calculation
{
    public static class SimpleCalculation
    {
        public static TypeOperation GetTypeOperation()
        {
            TypeOperation typeOperation;
        Start:
            Console.Write("Введите тип операции (0 - сложение, 1- вычитание, 2-умножение, 3 -деление, 4-возведение в степень, 5 - остаток от деления): ");

            try
            {
                typeOperation = (TypeOperation)Enum.Parse(typeof(TypeOperation), Console.ReadLine());
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Введено некорректное значение... Повторите ввод.");
                goto Start;
            }
            catch
            {
                Console.WriteLine("Что-то не то... Повторите ввод.");
                goto Start;
            }


            return typeOperation;
        }

        public static double GetValueFromConsole()
        {
            double val1;

        start:
            Console.Write("Введите число: ");
            string str = Console.ReadLine();

            try
            {
                val1 = Convert.ToDouble(str);
            }
            catch (FormatException)
            {
                Console.WriteLine("Входная строка имела неверный формат.\nПовторите попытку ввода...");
                goto start;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Слишком большое число.\nПовторите попытку ввода...");
                goto start;
            }
            catch
            {
                Console.WriteLine("Вообще какая-то хрень.\nПовторите попытку ввода...");
                goto start;
            }

            return val1;
        }

        public static void Calculate(double val1, double val2, TypeOperation typeOperation)
        {
            switch (typeOperation)
            {
                case TypeOperation.Add:
                    Console.WriteLine("{0} + {1} = {2}", val1, val2, val1 + val2);
                    break;
                case TypeOperation.Minus:
                    Console.WriteLine("{0} - {1} = {2}", val1, val2, val1 - val2);
                    break;
                case TypeOperation.Multiply:
                    Console.WriteLine("{0} * {1} = {2}", val1, val2, val1 * val2);
                    break;
                case TypeOperation.Divide:
                    Console.WriteLine("{0} / {1} = {2}", val1, val2, val1 / val2);
                    break;
                case TypeOperation.Pow:
                    Console.WriteLine("{0} ^ {1} = {2}", val1, val2, Math.Pow(val1, val2));
                    break;
                case TypeOperation.Procent:
                    Console.WriteLine("{0} % {1} = {2}", val1, val2, val1 % val2);
                    break;
                default:
                    Console.WriteLine("Неизвестная операция");
                    break;
            }
        }
    }

    public static class Types
    {
        public enum TypeOperation
        {
            Add,
            Minus,
            Multiply,
            Divide,
            Pow,
            Procent
        }
    }
}
