using System;
using System.Collections.Generic;
using Telegram.Receiver.Core;

namespace TelegramReceiversList
{
    class Program
    {
        static List<TelegramReceiver> Receivers;

        static void Main(string[] args)
        {
            Receivers = new List<TelegramReceiver>()
            {
                new TelegramReceiver("5421635572:AAHLXcXKIAKzITLa82YDLUTxf9u1CsXpESo"),
                new TelegramReceiver("5311806749:AAHycjD4JaEckAHEeqI8Pdt-WkRbc6FGusY")
            };

            foreach (var Receiver in Receivers)
            {
                Receiver.MessageReceived += OnMessageReceived;
                Receiver.Run();
            }

            Console.ReadKey();

            foreach (var Receiver in Receivers)
                Receiver.Stop();


        }

        private static void OnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine($"{e.ContactId} {e.Message}");
        }
    }
}
