using System;


namespace Reminder.Domain.Models
{

    public class SendingFailedEventArgs : SendingSucceededEventArgs
    {
        public Exception SendingException { get; set; }
    }
}
