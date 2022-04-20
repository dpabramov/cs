using System;

namespace _16_Geometry_DLL
{
    public class Circle
    {
        private double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }

        public double Calculate(Func<double, double> operation)
        {
            return operation(_radius);
        }
    }

    public class Rectangle
    {
        public double SideA { get; private set; }

        public double SideB { get; private set; }

        public Rectangle(double sideA, double sideB)
        {
            SideA = sideA;
            SideB = sideB;
        }

        public double Operation(Func<double, double, double> op, Rectangle rectangle)
        {
            return op(rectangle.SideA, rectangle.SideB);
        }
    }
}
