using _013_AbstractClass.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _013_AbstractClass
{
    public class Plane : AirTehnik, IPlaner
    {
        public byte EngineCount { get; set; }

        public Plane(int maxHeight, byte engineCount) :
             base(maxHeight, 0)
        {
            EngineCount = engineCount;
            Console.WriteLine("it is a Plane. Welcome aboart!");
        }

        public override void WriteProperties()
        {
            Console.WriteLine($"Type: [{GetType().Name}]" +
                    $"\nMaxHeight: {MaxHeight}" +
                    $"\nCurentHeight: {CurentHeight}" +
                    $"\nEngineCount: {EngineCount}");
        }

        public override void TakeUpper(int delta)
        {
            if (delta <= 0)
                throw new ArgumentOutOfRangeException();

            CurentHeight = Math.Min(CurentHeight + delta, MaxHeight);
        }

        public override void TakeLower(int delta)
        {
            if (delta <= 0)
                throw new ArgumentOutOfRangeException();

            if ((CurentHeight - delta) < 0)
                throw new InvalidOperationException();
            else CurentHeight -= delta;
        }
    }
}
