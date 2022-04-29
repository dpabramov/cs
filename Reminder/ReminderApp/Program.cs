using Reminder.Domain;
using Reminder.Receiver.Telegram;
using Reminder.Receiver.Core;
using Reminder.Sender.Telegram;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using System;
using System.Net;
using Reminder.Parsing;
using MihaZupan;

namespace ReminderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ReminderApp Started");

            //создаем хранилище
            InMemoryReminderStorage storage = new InMemoryReminderStorage();

            //создаем домен
            var domain = new ReminderDomain(storage);

            //создаем sender
            //создаем в телеге бота и его токен пишем здесь
            string token = "5311806749:AAHycjD4JaEckAHEeqI8Pdt-WkRbc6FGusY";
            //IWebProxy proxy = null;//new HttpToSocks5Proxy("proxy.golyakov.net", 1080);

            var sender = new TelegramReminderSender(token);

            //подписываемся на сообщения отправки в домене.
            domain.SendReminder = (ReminderItem ri) =>
            {
                sender.Send(ri.ContactId, ri.Message);
            };

            //создаем receiver
            var receiver = new TelegramReminderReceiver(token);

            //подписываемся на сообщения приема,
            //по нему добавляем в хранилище запись
            receiver.MessageReceived += (object s, MessageReceivedEventArgs e) =>
                   {
                       Console.WriteLine($"Message received: {e.ContactId}\t{e.Message}");

                       ParsedMessage ParsedMessage = MessageParser.Parse(e.Message);

                       ReminderItem reminderItem = new ReminderItem(ParsedMessage.Date,
                           ParsedMessage.Message,
                           e.ContactId);

                       storage.Add(reminderItem);
                   };

            //стартуем прием сообщений
            receiver.Run();

            //стартуем отправку сообщений
            domain.Run();

            Console.WriteLine("Нажмите любую клавишу для завершения работы");
            Console.ReadKey();
        }
    }
}
