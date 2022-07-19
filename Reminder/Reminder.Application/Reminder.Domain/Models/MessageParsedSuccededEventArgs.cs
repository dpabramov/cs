using Reminder.Parsing;
using System;

namespace Reminder.Domain.Models
{
    public class MessageParsedSuccededEventArgs : EventArgs
    {
        public ParsedMessage Message;
    }
}