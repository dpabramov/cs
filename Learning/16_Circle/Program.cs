using System;
using _16_Geometry_DLL;

namespace _16_Circle
{
    class Program
    {
        static void Main(string[] args)
        {
            double radius = 10;
            Circle circle = new Circle(radius);

            Rectangle rectangle = new Rectangle(7, 3);


            //Console.WriteLine($"Для окружности радиусом {radius}: " +
            //    $"\nПериметр {circle.Calculate(Perimeter)}" +
            //    $"\nПлощадь {circle.Calculate(Square)}");

            Console.WriteLine($"Для окружности радиусом {radius}: " +
               $"\nПериметр {circle.Calculate((double r) => 2 * r * Math.PI)}" +
               $"\nПлощадь {circle.Calculate((double r) => Math.PI * Math.Pow(r, 2))}");

            Console.WriteLine($"Для прямоуголиника со сторонами  {rectangle.SideA} " +
                $"и {rectangle.SideB}: " +
               $"\nПериметр {rectangle.Operation((x, y) => 2 * (x + y),rectangle)}" +
               $"\nПлощадь  {rectangle.Operation((x, y) => x * y, rectangle)}");

            Console.ReadKey();
        }

        //static double Perimeter(double radius)
        //{
        //    return 2 * radius *Math.PI;
        //}

        //static double Square(double radius)
        //{
        //    return Math.PI * Math.Pow(radius, 2);
        //}
    }
}
