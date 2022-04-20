using System;
using System.Collections.Generic;
using System.Text;

namespace _15_GenericExample
{
    class Swapper<T>
    {
        public static void Swap(ref T a, ref T b)
        {
            T temp = a;

            a = b;

            b = temp;
        }
    }
}
