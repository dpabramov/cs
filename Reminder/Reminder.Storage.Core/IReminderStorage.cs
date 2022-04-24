using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Storage.Core
{
    public interface IReminderStorage
    {
        void Add(ReminderItem reminderItem);

        void Update(Guid guid, ReminderItemStatus status);

        ReminderItem Get(Guid guid);

        List<ReminderItem> Get(ReminderItemStatus status);
    }
}
