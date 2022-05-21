using System;

namespace Reminder.Domain.Models
{
    public class MessageParsedFaultEventArgs : EventArgs
    {
        public Exception MessageParseException { get; set; }
    }
}