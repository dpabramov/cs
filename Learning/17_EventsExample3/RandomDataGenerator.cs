using System;
using System.Collections.Generic;
using System.Text;

namespace _17_EventsExample3
{
    //public delegate void RandomDataGeneratedEventHandler(int bytesDone, int totalBytes);

    class RandomDataGenerator
    {
        //public event RandomDataEventArgs RandomDataGenerated;
        public event EventHandler<RandomDataEventArgs> RandomDataGenerated;

        public event EventHandler<RandomDataGenerationDoneEventArgs> RandomDataGenerationDone;

        public byte[] GetRandomData(int dataSize, int bytesDoneToRaiseError)
        {
            Random random = new Random();

            byte[] result = new byte[dataSize];

            for (int i = 0; i < dataSize; i++)
            {
                result[i] = (byte)random.Next(0x11111111);

                if ((i + 1) % bytesDoneToRaiseError == 0)
                {
                    RandomDataEventArgs randomDataEventArgs = new RandomDataEventArgs
                    {
                        bytesDone = i + 1,
                        totalBytes = dataSize
                    };

                    OnRandomDataGenerated(randomDataEventArgs);
                }
            }

            OnRandomDataGenerationDone(
                            new RandomDataGenerationDoneEventArgs
                            {
                                arr = result
                            });

            return result;
        }

        private void OnRandomDataGenerated(RandomDataEventArgs randomDataEventArgs)
        {
            RandomDataGenerated?.Invoke(this, randomDataEventArgs);
        }

        private void OnRandomDataGenerationDone(RandomDataGenerationDoneEventArgs e)
        {
            RandomDataGenerationDone?.Invoke(this, e);
        }
    }
}
