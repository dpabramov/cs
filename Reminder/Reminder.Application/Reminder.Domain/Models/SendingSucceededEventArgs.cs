using Reminder.Storage.Core;
using System;


namespace Reminder.Domain.Models
{
    //public delegate bool SendMessageEventHandler(string ContactId, string Message);

    public class SendingSucceededEventArgs : EventArgs
    {
        public ReminderItem Item { get; set; }
    }
}
