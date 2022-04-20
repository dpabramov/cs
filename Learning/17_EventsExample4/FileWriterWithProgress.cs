using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _17_EventsExample4
{
    //public delegate void WritingPerformedEventHandler(float percentageWritten);

    class FileWriterWithProgress
    {
        //public event WritingPerformedEventHandler WritingPerformed;
        public event EventHandler<WritingPerformedEventArgs> WritingPerformed;

        public event EventHandler WritingCompleted;

        public void WriteBites(string fileName, byte[] array, float percentageToFireEvent)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    fileStream.WriteByte(array[i]);

                    WritingPerformedEventArgs writingPerformedEventArgs = new WritingPerformedEventArgs
                    {
                        percentageWritten = (i + 1) * 100 / ((float)array.Length)
                    };

                    if ((i + 1) % (array.Length * percentageToFireEvent / 100) == 0)
                    {
                        WritingPerformed?.Invoke(this, writingPerformedEventArgs);
                    }
                }

                WritingCompleted?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
