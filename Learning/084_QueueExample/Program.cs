using System;
using System.Collections;

namespace _084_QueueExample
{
    class Program
    {
        static void Main(string[] args)
        {
            const string run = "run";
            const string exit = "exit";
            Queue queue = new Queue();
            //string inputString;
            
            do
            {
                Console.Write("Введите натуральное число: ");
                string inputString = Console.ReadLine();

                if (inputString.Equals(run, StringComparison.InvariantCultureIgnoreCase))
                {
                    while (queue.Count!=0)
                    {
                        int i = (int)queue.Dequeue();
                        double res = Math.Sqrt((double)i);

                        Console.WriteLine($"Корень из {i} равен {res:0.0000}");
                    }
 
                    break;
                }

                if (inputString.Equals(exit, StringComparison.InvariantCultureIgnoreCase))
                {
                    while (queue.Count != 0)
                    {
                        int i = (int)queue.Dequeue();
                        
                        Console.WriteLine($"Необработанные значения в очереди {i}");
                    }
                    break;
                }

                if (int.TryParse(inputString, out int inputInt))
                    queue.Enqueue(inputInt);
                else
                {
                    Console.WriteLine("Введено некорректное значение. Повторите попытку...");
                    continue;
                }

            } while (true);

            Console.ReadKey();
        }
    }
}
