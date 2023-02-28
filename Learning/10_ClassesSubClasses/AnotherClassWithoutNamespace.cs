using System;

class AnotherClassWithoutNamespace
{
    public static void Print()
    {
        Console.WriteLine("Class AnotherClassWithoutNamespace, method Print");
    }

    public class SubClass
    {
        public static void Print()
        {
            Console.WriteLine("Class SubClass AnotherClassWithoutNamespace, method Print");
        }
    }
}
