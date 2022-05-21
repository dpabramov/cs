using Reminder.Storage.Core;
using System;

namespace Reminder.Domain
{
    public class AddedStorageSuccededEventArgs : EventArgs
    {
        public ReminderItem ReminderItem;
    }
}