using System;
using static BaseCalculations.Types;

namespace BaseCalculations
{
    public static class SimpleCalculations
    {
        public static TypeOperation GetTypeOperation()
        {
            TypeOperation? typeOperation = null;
        
            Console.Write(
                "Введите тип операции " +
                "(0 - сложение, " +
                "1 - вычитание, " +
                "2 - умножение, " +
                "3 - деление, " +
                "4 - возведение в степень, " +
                "5 - остаток от деления): ");

            do
            {
                try
                {
                    typeOperation = (TypeOperation)Enum.Parse(typeof(TypeOperation), Console.ReadLine());
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Введено некорректное значение... Повторите ввод.");
                }
                catch
                {
                    Console.WriteLine("Что-то не то... Повторите ввод.");
                }

                if (typeOperation.HasValue)
                    break;

            } while (true);
            

            return (TypeOperation)typeOperation;
        }

        public static double GetValueFromConsole()
        {

            double? val1 = null;
            Console.Write("Введите число: ");
            
            do
            {
                try
                {
                    val1 = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Входная строка имела неверный формат.\nПовторите попытку ввода...");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Слишком большое число.\nПовторите попытку ввода...");
                }
                catch
                {
                    Console.WriteLine("Вообще какая-то хрень.\nПовторите попытку ввода...");
                }

                if (val1.HasValue)
                    break;

            } while (true);
 
            return (double)val1;
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
