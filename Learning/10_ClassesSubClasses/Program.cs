using AnotherNamespace;
using System;

namespace _10_ClassesSubClasses
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Print();

            SubClassProgram.Print();

            AnotherClassInSameNamespace.Print();

            AnotherClassInSameNamespace.AnotherSubclass.Print();

            AnotherClassInAnotherNamespace.Print();

            AnotherClassInAnotherNamespace.AnotherSubclass.Print();

            AnotherClassWithoutNamespace.Print();

            AnotherClassWithoutNamespace.SubClass.Print();

            Console.ReadKey();
        }

        static void Print()
        {
            Console.WriteLine("Class Program, method Print");
        }
    }
}
