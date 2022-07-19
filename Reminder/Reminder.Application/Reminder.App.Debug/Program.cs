using System;
using System.Collections.Generic;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using Reminder.Storage.WebApi.Client;

namespace Test.WebApi.Client.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //var client = new ReminderStorageWebApiClient("https://localhost:5001");
            var client = new InMemoryReminderStorage();

            ReminderItem reminderItem = new ReminderItem(Guid.NewGuid(), 
                                    DateTimeOffset.Now.AddDays(2), 
                                    "Hi, Diman", 
                                    "123456", 
                                    ReminderItemStatus.Awaiting);

            Console.WriteLine($"Исходный объект: " +
                $"{reminderItem.Id}; " +
                $"{reminderItem.Date}; " +
                $"{reminderItem.Message}; " +
                $"{reminderItem.Status}; " +
                $"{reminderItem.ContactId}");

            Guid id = client.Add(reminderItem);

            Console.WriteLine($"Добавлен в хранилище новый объект id = {id}");

            ReminderItem ri = client.Get(id);

            Console.WriteLine($"Получен из хранилища объект: " +
                $"{id}; " +
                $"{ri.Date}; " +
                $"{ri.Message}; " +
                $"{ri.Status}; " +
                $"{ri.ContactId}");

            client.Update(ri.Id, ReminderItemStatus.Ready);

            ReminderItem ri2 = client.Get(id);

            Console.WriteLine($"Обновлен в хранилище объект: " +
                $"{id}; " +
                $"{ri2.Date}; " +
                $"{ri2.Message}; " +
                $"{ri2.Status}; " +
                $"{ri2.ContactId}");

            List<ReminderItem> reminders = client.Get(ReminderItemStatus.Awaiting);
            foreach(ReminderItem item in reminders)
            {
                Console.WriteLine($"{item.Id}; " +
                                                    $"{item.Date}; " +
                                                    $"{item.Message}; " +
                                                    $"{item.Status}; " +
                                                    $"{item.ContactId}");
            }

            List<ReminderItem> reminders2 = client.Get(ReminderItemStatus.Ready);
            foreach (ReminderItem item in reminders2)
            {
                Console.WriteLine($"{item.Id}; " +
                                                    $"{item.Date}; " +
                                                    $"{item.Message}; " +
                                                    $"{item.Status}; " +
                                                    $"{item.ContactId}");
            }


            Console.ReadKey();
        }
    }
}
