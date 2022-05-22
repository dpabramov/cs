using Reminder.Storage.Core;
using System;

namespace Reminder.Domain
{
    public class AddedStorageFaultEventArgs: EventArgs
    {
        public ReminderItem Reminder;

        public Exception Except;
    }
}