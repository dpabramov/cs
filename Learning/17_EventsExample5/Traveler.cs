using System;
using System.Collections.Generic;
using System.Text;

namespace _17_EventsExample5
{
    //public delegate void DistantPerformedEventHandler(int curent, int total);

    public class Traveler
    {
        public string Name { get; set; }

        //public event DistantPerformedEventHandler DistantPerformed;
        public event EventHandler<DistantPerformedEventArgs> DistantPerformed;

        public event EventHandler<DistantCompletedEventArgs> DistantCompleted;

        public event EventHandler<DistantCompletedEventArgs> DistantStarted;

        public void Go(int distant, int procentToFireEvent)
        {
            OnDistantStarted(distant);

            for (int i = 1; i <= distant; i++)
            {
                if (((i) * 100 / distant)% procentToFireEvent ==0)
                {
                    OnDistantPerformed(i, distant);
                }
            }
            OnDistantCompleted(distant);
        }

        private void OnDistantStarted(int distant)
        {
            DistantCompletedEventArgs distantCompletedEventArgs = new DistantCompletedEventArgs
            {
                total = distant
            };

            DistantStarted?.Invoke(this, distantCompletedEventArgs);
        }

        private void OnDistantCompleted(int distant)
        {
            DistantCompletedEventArgs distantCompletedEventArgs = new DistantCompletedEventArgs
            {
                total = distant
            };

            DistantCompleted?.Invoke(this, distantCompletedEventArgs);
        }

        private void OnDistantPerformed(int performed, int total)
        {
            DistantPerformed?.Invoke(performed,
                                           new DistantPerformedEventArgs
                                           {
                                               Curent = performed,
                                               Total = total
                                           });
        }


    }
}
