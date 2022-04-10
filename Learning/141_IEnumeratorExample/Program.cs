using System;

namespace _141_IEnumeratorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            SomeIntValue someIntValue = new SomeIntValue(5);

            foreach (int i in someIntValue)
                Console.Write(i + " ");


            Console.ReadKey();
        }
    }
}
