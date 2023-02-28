using System;

namespace Telegram.Receiver.Core
{
    public class MessageReceivedEventArgs : EventArgs
    {
        public string ContactId;

        public string Message;
    }
}