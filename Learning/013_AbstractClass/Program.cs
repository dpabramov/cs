using System;

namespace _013_AbstractClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Helicopter helicopter = new Helicopter(550, 4);

            helicopter.WriteProperties();

            helicopter.TakeUpper(400);

            helicopter.WriteProperties();

            helicopter.TakeLower(200);

            helicopter.WriteProperties();

            Plane plane = new Plane(1000, 2);

            plane.WriteProperties();

            plane.TakeUpper(750);

            plane.WriteProperties();

            plane.TakeLower(150);

            plane.WriteProperties();

            Console.ReadKey();
        }
    }
}
