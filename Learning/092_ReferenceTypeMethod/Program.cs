using System;

namespace _092_ReferenceTypeMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            const int length = 10;
            const int maxValue = 100;

            Random random = new Random();

            int[] arr = new int[length];

            for(int i = 0; i< arr.Length; i++)
            {
                arr[i] = random.Next(maxValue);
            }



            Console.ReadKey();
        }
    }
}
