using System;
using System.Collections.Generic;
using System.Text;

namespace _17_EventsExample5
{
    public class DistantPerformedEventArgs : EventArgs
    {
       public int Total { get; set; }

        public int Curent { get; set; }

        public int Rest { get => Total - Curent;}
    }

    public class DistantCompletedEventArgs : EventArgs
    {
        public int total;
    }
}
