using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _16_DelegateExample
{
    class SimpleCalculator
    {
        public int Sum(int a, int b)
        {
            Debug.WriteLine($"Вызов метода Sum с параметрами {a} {b}");
            return a + b;
        }

        public int Multiply(int a, int b)
        {
            Debug.WriteLine($"Вызов метода Multiply с параметрами {a} {b}");
            return a * b;
        }

        public int Devide(int a, int b)
        {
            Debug.WriteLine($"Вызов метода Devide с параметрами {a} {b}");
            return a * b;
        }
    }
}
