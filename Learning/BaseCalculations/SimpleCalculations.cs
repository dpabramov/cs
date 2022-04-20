using System;

namespace BaseCalculations
{
    public class SimpleCalculator
    {
        private static string _stringFormat = "{0} {2} {1} = {3}";

        public static double Summ(double a, double b)
        {
            return a + b;
        }

        public static double Minus(double a, double b)
        {
            return a - b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Devide(double a, double b)
        {
            return a / b;
        }

        public static void Calculate(Func<double, double, double> op, 
                                double argument1, 
                                double argument2, 
                                string oper)
        {
            double result = op(argument1, argument2);
            Console.WriteLine(string.Format(_stringFormat, 
                                            argument1, 
                                            argument2, 
                                            oper, 
                                            result));
        }
    }
}
