using System;
using System.Text;

namespace _01_Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            //ввод и вывод на консоль в юникоде
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            ConsoleKeyInfo cki;

            do
            {
                double a, b, c;
                double? d = null;
                double? x1 = null;
                double? x2 = null;

                Console.WriteLine("\nРешаем квадратное уравнение.\n");
                Console.Write("Введите коэффициент a: ");
                a = GetDoubleValueFromConsole();
                Console.Write("Введите коэффициент b: ");
                b = GetDoubleValueFromConsole();
                Console.Write("Введите коэффициент c: ");
                c = GetDoubleValueFromConsole();

                //расчет корней уравнения
                GetRootsQuadraticEquation(a, b, c, ref d, ref x1, ref x2);

                //вывод на экран
                WriteConsoleDesigionQuadraticEquation(a, b, c, d, x1, x2);

                Console.WriteLine("\nДля продолжения нажмите любую клавишу." +
                    "\nДля выхода нажмите ESC...");
                cki = Console.ReadKey();
            } while (cki.Key != ConsoleKey.Escape);
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

        static void GetRootsQuadraticEquation(double a, double b, double c, ref double? d, ref double? x1, ref double? x2)
        {
            //расчет дискриминанта
            d = GetDiskriminant(a, b, c);

            if (d < 0)
            {
                x1 = null;
                x2 = null;
            }
            else if (d == 0)
            {
                x2 = x1 = -b / (2 * a);
            }
            else if (d > 0)
            {
                x1 = (-b + Math.Sqrt((double)d)) / (2 * a);
                x2 = (-b - Math.Sqrt((double)d)) / (2 * a);
            }
        }

        static double GetDiskriminant(double a, double b, double c)
        {
            return Math.Pow(b, 2) - 4 * a * c;
        }

        static void WriteConsoleDesigionQuadraticEquation(double a, double b, double c, double? d, double? x1, double? x2)
        {
            string bb = b > 0 ? "+" : "-";
            string bbb = b > 0 ? b.ToString() : "(" + b.ToString() + ")";
            string bbbb;
            string cc = c > 0 ? "+" : "-";
            string aa = a > 0 ? a.ToString() : "(" + a.ToString() + ")";
            string aaa;
            string ac;

            if (a == 1)
                aaa = string.Empty;
            else if (a == -1)
                aaa = "-";
            else
                aaa = a.ToString();

            if ((a < 0 && c < 0) || (a > 0 && c > 0))
                ac = "-";
            else
                ac = "+";

            if (Math.Abs(b) == 1)
                bbbb = string.Empty;
            else
                bbbb = Math.Abs(b).ToString();


            Console.WriteLine($"\n{aaa}x\u00b2 {bb} {bbbb}x {cc} {Math.Abs(c)} = 0");
            Console.WriteLine($"D = b\u00b2 - 4ac");
            Console.WriteLine($"D = {bbb}\u00b2 {ac} 4 * {Math.Abs(a)} * {Math.Abs(c)} = {d}");

            if (d < 0)
                Console.WriteLine($"Нет решений, так как {d} < 0 ");
            else if (d == 0)
            {
                Console.WriteLine($"x = -b/2a");
                Console.WriteLine($"x = {-b} /2*{aa}");
                Console.WriteLine($"x = {x1}");
            }
            else if (d > 0)
            {
                Console.WriteLine($"x\u2081,\u2082 = (-b \u00b1 \u221aD )/(2a)");
                Console.WriteLine($"x\u2081,\u2082 = ({-b} \u00b1 \u221a{d}) /(2*{aa})");
                Console.WriteLine($"x\u2081 = {x1}");
                Console.WriteLine($"x\u2082 = {x2}");
            }
            else
                Console.WriteLine("У программиста проблемы с логикой...");
        }
    }
}
