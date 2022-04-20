using System;
using System.Collections.Generic;
using System.Text;

namespace _17_EventsExample3
{
    public class RandomDataEventArgs : EventArgs
    {
        public int bytesDone { get; set; }

        public int totalBytes { get; set; }
    }

    public class RandomDataGenerationDoneEventArgs : EventArgs
    {
        public byte[] arr { get; set; }
    }
}
