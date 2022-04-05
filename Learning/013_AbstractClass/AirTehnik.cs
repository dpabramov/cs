using _013_AbstractClass.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _013_AbstractClass
{
    public abstract class AirTehnik : IFlyer, IWriterProperties
    {
        public int MaxHeight { get; set; }

        public int CurentHeight { get; set; }

        public AirTehnik(int maxHeight, int curentHeight)
        {
            MaxHeight = maxHeight;
            CurentHeight = curentHeight;
        }

        public abstract void WriteProperties();

        public abstract void TakeUpper(int delta);

        public abstract void TakeLower(int delta);
    }
}
