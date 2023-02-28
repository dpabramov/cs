using System;

namespace TelegramExample
{
    public class MessageReceivedEventArgs : EventArgs
    {
        public string ContactId { get; set; }

        public string Message { get; set; }
    }
}