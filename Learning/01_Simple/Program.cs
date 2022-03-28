using System;


namespace _01_Simple
{
    class Program
    {
        static void Main(string[] args)
        {
           for(int i = 1; i<=10; i++ )
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.Write($" {i} * {j} = {j * i}\t");
                }
                Console.WriteLine();
            }
                       //Console.WriteLine(s3);



            //double a;
            //double b;
            //double c;
            //double d;

            //Console.WriteLine("Решаем квадратное уравнение.");
            //Console.Write("Введите коэффициент a: ");
            //a = GetDoubleValueFromConsole();
            //Console.Write("Введите коэффициент b: ");
            //b = GetDoubleValueFromConsole();
            //Console.Write("Введите коэффициент c: ");
            //c = GetDoubleValueFromConsole();

            ////расчет дискриминанта
            //d = Math.Pow(b, 2) - 4 * a * c;

            //if (d < 0)
            //    Console.WriteLine($"Нет решений, т.к. {d} < 0 ");
            //if (d == 0)
            //    Console.WriteLine($"x = {-b / (2 * a)}");
            //if (d > 0)
            //{
            //    double x1 = (-b + Math.Sqrt(d)) / (2 * a);
            //    double x2 = (-b - Math.Sqrt(d)) / (2 * a);

            //    string bb = (b > 0 ? "+" : "-");
            //    string cc = (c > 0 ? "+" : "-");

            //    string ac;
            //    if ((a < 0 && c < 0) || (a > 0 && c > 0))
            //        ac = "-";
            //    else
            //        ac = "+";

            //    string aa = a > 0 ? a.ToString() : "(" + a.ToString() + ")";

            //    Console.WriteLine($"{a}x*x {bb} {Math.Abs(b)}x {cc} {Math.Abs(c)} = 0");
            //    Console.WriteLine($"D = {b * b} {ac} 4 * {Math.Abs(a)} * {Math.Abs(c)} = {d}");
            //    Console.WriteLine($"x1 = ({-b} + SQRT({d})) /2*{aa}");
            //    Console.WriteLine($"x2 = ({-b} - SQRT({d})) /2*{aa}");
            //    Console.WriteLine($"x1= {x1}, x2= {x2}");
            //}

            Console.ReadKey();
        }

        static double GetDoubleValueFromConsole()
        {
            double? a = null;
            do
            {
                try
                {
                    a = Double.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введено некорректное значение. Повторите попытку...");
                    continue;
                }
            } while (a == null);
            return (double)a;
        }
    }
}
