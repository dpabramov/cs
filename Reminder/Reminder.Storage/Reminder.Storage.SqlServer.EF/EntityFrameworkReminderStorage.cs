using Microsoft.EntityFrameworkCore;
using Reminder.Storage.Core;
using Reminder.Storage.SqlServer.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reminder.Storage.SqlServer.EF
{
    public class EntityFrameworkReminderStorage : IReminderStorage
    {
        private readonly DbContextOptionsBuilder<ReminderStorageContext> _builder;

        public EntityFrameworkReminderStorage(string connectionString)
        {
            _builder = new DbContextOptionsBuilder<ReminderStorageContext>()
                .UseSqlServer(connectionString);
        }

        public Guid Add(DateTimeOffset date, string message, string contactId, ReminderItemStatus status)
        {
            ReminderItem reminderItem = new ReminderItem()
            {
                Id = Guid.NewGuid(),
                Date = date,
                Message = message,
                ContactId = contactId,
                Status = status
            };

            using (var context = new ReminderStorageContext(_builder.Options))
            {
                context.ReminderItems.Add(reminderItem);
                context.SaveChanges();
            }

            return reminderItem.Id;
        }

        public ReminderItem Get(Guid guid)
        {
            using (var context = new ReminderStorageContext(_builder.Options))
            {
                var reminder = context
                        .ReminderItems
                        .FirstOrDefault(ri => ri.Id == guid);

                return reminder ?? null;
            }
        }

        public List<ReminderItem> Get(ReminderItemStatus status)
        {
            using (var context = new ReminderStorageContext(_builder.Options))
            {
                var reminders = context
                        .ReminderItems
                        .Where(ri => ri.Status == status).
                        ToList();

                return reminders ?? null;
            }
        }

        public void Update(Guid guid, ReminderItemStatus status)
        {
            using (var context = new ReminderStorageContext(_builder.Options))
            {
                var reminder = context
                        .ReminderItems
                        .FirstOrDefault(ri => ri.Id == guid);

                if (reminder != null)
                {
                    reminder.Status = status;
                    context.SaveChanges();
                }
            }
        }
    }
}
