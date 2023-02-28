using System;

namespace AnotherNamespace
{
    class AnotherClassInAnotherNamespace
    {
        public static void Print()
        {
            Console.WriteLine("Class AnotherClassInAnotherNamespace, method Print");
        }

        public class AnotherSubclass
        {
            public static void Print()
            {
                Console.WriteLine("Class AnotherSubclass AnotherClassInAnotherNamespace, method Print");
            }
        }
    }
}
