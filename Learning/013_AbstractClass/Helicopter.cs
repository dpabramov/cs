using _013_AbstractClass.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _013_AbstractClass
{
    public class Helicopter : AirTehnik, IHelicopter
    {
        public byte BladeCount { get; set; }

        public Helicopter(int maxHeight, byte bladeCount) :
          base(maxHeight, 0)
        {
            BladeCount = bladeCount;
            Console.WriteLine("it is a Helicopter. Welcome aboart!");
        }

        public override void WriteProperties()
        {
            Console.WriteLine($"Type: [{GetType().Name}]" +
                    $"\nMaxHeight: {MaxHeight}" +
                    $"\nCurentHeight: {CurentHeight}" +
                    $"\nBladeCount: {BladeCount}");
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
