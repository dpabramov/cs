using System;

namespace _091_ValueTypesMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            Console.WriteLine(i);

            UpdateValue(ref i);
            Console.WriteLine(i);


            Console.ReadKey();
        }

        static void UpdateValue(ref int i)
        {
            i++;
        }
    }
}
