using System;
using Reminder.Domain;
using Reminder.Domain.Models;
using Reminder.Receiver.Telegram;
using Reminder.Sender.Telegram;
using Reminder.Storage.InMemory;

namespace ReminderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ReminderApp Started");

            //создаем в телеге бота и его токен пишем здесь
            string token = "5311806749:AAHycjD4JaEckAHEeqI8Pdt-WkRbc6FGusY";
            //IWebProxy proxy = null;//new HttpToSocks5Proxy("proxy.golyakov.net", 1080);

            var domain = new ReminderDomain(new InMemoryReminderStorage(),
                                new TelegramReminderReceiver(token),
                                new TelegramReminderSender(token));

            //подписываемся на событие получения сообщения
            domain.MessageReceived += (object sender, MessageReceivedEventArgs e) =>
            {
                Console.WriteLine($"Message Received\t" +
                                            $"Contact:{e.ContactId}\t" +
                                            $"Текст: {e.Message}");
            };

            //подписываемся на сообщения успешного парсинга для отображения в консоли
            domain.MessageParsedSucceded += (s, e) =>
                        {
                            Console.WriteLine($"Parsing Succeded\t" +
                                            $"Дата:{e.Message.Date}\t" +
                                            $"Текст: {e.Message.Message}");
                        };

            //подписываемся на сообщения сбоя парсинга для отображения в консоли
            domain.MessageParsedFault += (s, e) =>
                        {
                            Console.WriteLine($"Parsing Fault\t" +
                            $"{e.MessageParseException.Message}");
                        };

            //подписываемся на сообщения успешного добавления в хранилище 
            //для отображения в консоли
            domain.AddToStorageSucceded += (s, e) =>
                        {
                            Console.WriteLine($"Added to storage successfuly\t" +
                                $"{e.ReminderItem.ContactId}\t" +
                                        $"{e.ReminderItem.Date}\t" +
                                        $"{e.ReminderItem.Message}\t" +
                                        $"{e.ReminderItem.Status}");
                        };

            //подписываемся на сообщения успешного добавления в хранилище 
            //для отображения в консоли
            domain.AddToStorageFault += (object s, AddedStorageFaultEventArgs e) =>
                        {
                            Console.WriteLine($"Add to storage Fault\t" +
                                               $"{e.exception.Message}");
                        };

            //подписываемся на сообщения успешной отправки 
            domain.SendingSucceeded += (object sender, SendingSucceededEventArgs e) =>
            {
                Console.WriteLine($"Sending message succeded\t" +
                                                        $"{e.Item.Message}");
            };

            //стартуем отправку  и прием сообщений
            domain.Run();

            Console.WriteLine("Нажмите любую клавишу для завершения работы");
            Console.ReadKey();
        }
    }
}
