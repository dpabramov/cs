using System;

namespace TelegramExample
{
    public class MessageSentEventArgs: EventArgs
    {
        public string ContactId { get; set; }

        public string Message { get; set; }
    }
}