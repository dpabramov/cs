using System;

namespace EnumExample
{
    class Program
    {
        enum MathOperation { Add, Subtraction, Multiply, Divide };

        static void Main(string[] args)
        {
            MathOperation mathOperation = MathOperation.Subtraction;
            mathOperation.ToString();


            Console.ReadKey();
        }
    }
}
