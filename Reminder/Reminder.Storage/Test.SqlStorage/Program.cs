using System;
using System.Collections.Generic;
using Reminder.Storage.Core;
using Reminder.Storage.SqlServer.ADO;

namespace Test.SqlStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            var sqlServerReminderStorage = new SqlServerReminderStorage();

            ReminderItem reminderItem = sqlServerReminderStorage.Get(Guid.Parse(
                "02371C62-ACD9-4770-BD68-BB1D83614C2C"));

            List<ReminderItem> reminders = sqlServerReminderStorage.Get(ReminderItemStatus.Awaiting);

            Guid guid = sqlServerReminderStorage.Add(DateTimeOffset.Now,
                                                "Молодец",
                                                "contact_2",
                                                ReminderItemStatus.Awaiting);

            Guid guid1 = new Guid();
            guid1 = Guid.Parse("D1AFA882-E943-43F1-9829-5AC6098D95C0");
            sqlServerReminderStorage.Update(guid1, ReminderItemStatus.Ready);

            Console.ReadKey();
        }
    }
}
