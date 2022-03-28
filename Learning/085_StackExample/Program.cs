using System;
using System.Collections;

namespace _085_StackExample
{
    class Program
    {
        static void Main(string[] args)
        {
            const string wash = "wash";
            const string dry = "dry";
            const string exit = "exit";

            Stack stack = new Stack();

            do
            {
                Console.WriteLine($"Введите команду ({wash}/{dry}/{exit}):");
                string input = Console.ReadLine();

                if (input.Equals(wash, StringComparison.InvariantCultureIgnoreCase))
                {
                    stack.Push(1);
                    Console.WriteLine($"В стопке стало {stack.Count} тарелок.");
                }

                else if (input.Equals(dry, StringComparison.InvariantCultureIgnoreCase))
                    if (stack.Count != 0)
                    {
                        stack.Pop();
                        Console.WriteLine($"В стопке стало {stack.Count} тарелок.");
                    }
                    else
                    {
                        Console.WriteLine($"В стопке нет тарелок, вытирать нечего.");
                    }

                else if (input.Equals(exit, StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine($"В стопке осталось {stack.Count} тарелок.");
                    break;
                }
                else
                    Console.WriteLine("Неизвестная команда, повторите ввод...");
            } while (true);

            Console.ReadKey();
        }
    }
}
