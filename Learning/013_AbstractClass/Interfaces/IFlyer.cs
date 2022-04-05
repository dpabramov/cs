using System;
using System.Collections.Generic;
using System.Text;

namespace _013_AbstractClass.Interfaces
{
    public interface IFlyer
    {
        int MaxHeight { get; set; }

        int CurentHeight { get; set; }

        void TakeUpper(int delta);

        void TakeLower(int delta);
    }
}
