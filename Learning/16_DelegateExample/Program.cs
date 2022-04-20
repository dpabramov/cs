using System;

namespace _16_DelegateExample
{
    class Program
    {
        //объявим делагат
        delegate int DoCalculation(int a, int b);

        static void Main(string[] args)
        {
            //переменная типа делегата
            DoCalculation doCalc;
                       
            SimpleCalculator sc = new SimpleCalculator();
            //Console.WriteLine(sc.Sum(1,4));
            //Console.WriteLine(sc.Multiply(1, 4));

            //теперь в переменную можно поместить любой метод
            //соответствующей сигнатуры
            doCalc = sc.Sum;

            //теперь вызывая doCalc будет выполняться метод которые внутри него
            Console.WriteLine(doCalc(1, 4));

            //поместим в делегат второй метод
            doCalc = sc.Multiply;
            Console.WriteLine(doCalc(1, 4));

            //можно совместить объявление и инициализацию делегата
            DoCalculation doCalc2 = new DoCalculation(sc.Multiply);
            doCalc2 += sc.Devide;

            Console.WriteLine(doCalc2(6, 2));

            Console.ReadKey();
        }
    }
}
