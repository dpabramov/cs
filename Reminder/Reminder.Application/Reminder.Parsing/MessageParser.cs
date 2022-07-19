using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Parsing
{
    public class MessageParser
    {
        public static ParsedMessage Parse(string message)
        {
            int spaceIndex = message.IndexOf(' ');
            return new ParsedMessage
            {
                Date = DateTimeOffset.Parse(message.Substring(0, spaceIndex)),
                Message = message.Substring(spaceIndex + 1)
            };
        }
    }
}
