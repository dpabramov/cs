using System;

namespace Reminder.Receiver.Core.Models
{
    public class MessageReceivedEventArgs : EventArgs
    {
        public string ContactId { get; set; }

        public string Message { get; set; }
    }
}