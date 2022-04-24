using System;
using System.Linq;
using System.Collections.Generic;
using Reminder.Storage.Core;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Reminder.Storage.InMemory.Test")]

namespace Reminder.Storage.InMemory
{
    public class InMemoryReminderStorage : IReminderStorage
    {
        internal Dictionary<Guid, ReminderItem> reminders;

        public InMemoryReminderStorage()
        {
            reminders = new Dictionary<Guid, ReminderItem>();
        }

        public void Add(ReminderItem reminderItem)
        {
            reminders.Add(reminderItem.Id, reminderItem);
        }

        public ReminderItem Get(Guid guid)
        {
            //ReminderItem reminderItem = new ReminderItem();
            //if (reminders.TryGetValue(guid, out reminderItem))
            //    return reminderItem;
            //else return null;

            //if (reminders.ContainsKey(guid))
            //{
            //    return reminders[guid];
            //}
            //else
            //    return null;

            return reminders.ContainsKey(guid)
                 ? reminders[guid]
                 : null;
        }

        public List<ReminderItem> Get(ReminderItemStatus status)
        {
            //List<ReminderItem> result = new List<ReminderItem>();

            //foreach (KeyValuePair<Guid, ReminderItem> reminder in reminders)
            //{
            //    if (reminder.Value.Status == status)
            //    {
            //        result.Add(reminder.Value);
            //    }
            //}

            //так прикольней
            return reminders
                .Values
                .Where((ReminderItem ri) => ri.Status == status)
                .ToList();
        }

        public void Update(Guid guid, ReminderItemStatus status)
        {
            if (reminders.ContainsKey(guid))
                reminders[guid].Status = status;
        }
    }
}
