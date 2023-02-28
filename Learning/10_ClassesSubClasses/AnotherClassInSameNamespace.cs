using System;

namespace _10_ClassesSubClasses
{
    class AnotherClassInSameNamespace
    {
        public static void Print()
        {
            Console.WriteLine("Class AnotherClassInSameNamespace, method Print");
        }

        public class AnotherSubclass
        {
            public static void Print()
            {
                Console.WriteLine("Class AnotherSubclass AnotherClassInSameNamespace, method Print");
            }
        }
    }
}
