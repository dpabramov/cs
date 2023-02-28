using System;

namespace Telegram.Receiver.Core
{
    public interface IReceiver
    {
        void Run();

        void Stop();

        event EventHandler<MessageReceivedEventArgs> MessageReceived;
    }
}