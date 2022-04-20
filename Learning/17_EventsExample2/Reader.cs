using System;

namespace _17_EventsExample2
{
    public delegate void PartReadFinisedEventHandler(int procent);

    class Reader
    {
        public event EventHandler ReadStarted;

        public event PartReadFinisedEventHandler PartReadFinished;

        public event EventHandler ReadFinished;

        public void ToRead()
        {
            ReadStarted?.Invoke(this, EventArgs.Empty);

            for (int procent = 1; procent <= 10; procent++)
            {
                System.Threading.Thread.Sleep(1000);

                OnPartReadFinished(procent * 10);
            }

            ReadFinished?.Invoke(this, EventArgs.Empty);
        }

        public void OnPartReadFinished(int procent)
        {
            PartReadFinished?.Invoke(procent);
        }
    }
}
