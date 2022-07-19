using System;
using Newtonsoft.Json;
using Reminder.Domain;
using Reminder.Domain.Models;
using Reminder.Receiver.Telegram;
using Reminder.Sender.Telegram;
using Reminder.Storage.InMemory;
using Reminder.Storage.WebApi.Client;

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

            var domain = new ReminderDomain(new ReminderStorageWebApiClient("https://localhost:5001"),
            //var domain = new ReminderDomain(new InMemoryReminderStorage(),
                                new TelegramReminderReceiver(token),
                                new TelegramReminderSender(token));

            //подписываемся на событие получения сообщения
            domain.MessageReceived += (sender, e) =>
                        {
                            Console.WriteLine($"Message Received\t{JsonConvert.SerializeObject(e)}");
                        };

            //подписываемся на сообщения успешного парсинга
            domain.MessageParsedSucceded += (s, e) =>
                        {
                            Console.WriteLine($"Parsing Succeded\t{JsonConvert.SerializeObject(e)}");
                        };

            //подписываемся на сообщения сбоя парсинга
            domain.MessageParsedFault += (s, e) =>
                        {
                            string message = $"Parsing Fault\t{JsonConvert.SerializeObject(e)}";
                            WriteToConsoleWithRed(message);
                        };

            //подписываемся на сообщения успешного добавления в хранилище 
            domain.AddToStorageSucceded += (s, e) =>
                        {
                            Console.WriteLine($"Added to storage successfuly\t" +
                               $"{JsonConvert.SerializeObject(e)}");
                        };

            //подписываемся на сообщения не успешного добавления в хранилище 
            domain.AddToStorageFault += (object s, AddedStorageFaultEventArgs e) =>
                        {
                            string message = $"Add to storage Fault\t{JsonConvert.SerializeObject(e)}";
                            WriteToConsoleWithRed(message);
                        };

            //подписываемся на сообщения успешной отправки 
            domain.SendingSucceeded += (object sender, SendingSucceededEventArgs e) =>
                        {
                            Console.WriteLine($"Sending message succeded\t{JsonConvert.SerializeObject(e)}");
                        };

            //стартуем все
            domain.Run();

            Console.WriteLine("Нажмите любую клавишу для завершения работы");
            Console.ReadKey();
        }

        public static void WriteToConsoleWithRed(string text)
        {
            var remember = Console.ForegroundColor;
            Console.ForegroundColor = System.ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = remember;
        }
    }
}
