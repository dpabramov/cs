using Reminder.Storage.Core;
using System;


namespace Reminder.Domain
{
    //public delegate bool SendMessageEventHandler(string ContactId, string Message);

    public class SuccessSendMessageEventArgs : EventArgs
    {
        public ReminderItem ReminderItem;
    }

    public class FailSendMessageEventArgs : SuccessSendMessageEventArgs
    {
        public Exception Exception;
    }
}
