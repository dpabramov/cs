using System;
using AnotherNameSpace;

namespace _10_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AnotherClass.PrintFromAnotherClass();
            AnotherClass.InsideClass.PrintFromInsideClass();
            OutNameSpaceClass.PrintFromOutNameSpaceClass();
            OutNameSpaceClass.InsideClass.PrintFromInsideClass();
            InsideClass.PrintFromInsideClass();
            Console.ReadKey();
        }

        class InsideClass
        {
            public static void PrintFromInsideClass()
            {
                Console.WriteLine("PrintFromInsideClass");
            }
        }
    }
}

namespace AnotherNameSpace
{
    class AnotherClass
    {
        public static void PrintFromAnotherClass()
        {
            Console.WriteLine("PrintFromAnotherClass");
        }

        public static class InsideClass
        {
            public static void PrintFromInsideClass()
            {
                Console.WriteLine("AnotherClass.PrintFromInsideClass");
            }
        }
    }
}

class OutNameSpaceClass
{
    public static void PrintFromOutNameSpaceClass()
    {
        Console.WriteLine("OutNameSpaceClass.PrintFromOutNameSpaceClass");
    }

    public static class InsideClass
    {
        public static void PrintFromInsideClass()
        {
            Console.WriteLine("OutNameSpaceClass.PrintFromInsideClass");
        }
    }
}