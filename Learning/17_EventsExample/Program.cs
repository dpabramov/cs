using System;

namespace _17_EventsExample
{
    public enum DoWorker { Work, NotWork };

    class Program
    {
        delegate void DoWorkEventHandler(int Hours, DoWorker workType);

        static void Main(string[] args)
        {
            DoWorkEventHandler doWorkEventHandler = PerformWork1;

            doWorkEventHandler += PerformWork2;

            doWorkEventHandler += PerformWork3;

            doWorkEventHandler(2, DoWorker.Work);

            Console.ReadLine();
        }

        private static void PerformWork1(int Hours, DoWorker workType)
        {
            Console.WriteLine($"[1] We do {workType} for {Hours} hours");
        }

        private static void PerformWork2(int Hours, DoWorker workType)
        {
            Console.WriteLine($"[2] We do {workType} for {Hours} hours");
        }

        private static void PerformWork3(int Hours, DoWorker workType)
        {
            Console.WriteLine($"[3] We do {workType} for {Hours} hours");
        }


    }
}
