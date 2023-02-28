using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramExample2
{
    class Program
    {
        public static Dictionary<string, TelegramBotClient> clients = new Dictionary<string, TelegramBotClient>();

        static void Main(string[] args)
        {
            clients.Add("5421635572:AAHLXcXKIAKzITLa82YDLUTxf9u1CsXpESo",
                        new TelegramBotClient("5421635572:AAHLXcXKIAKzITLa82YDLUTxf9u1CsXpESo"));

            clients.Add("5311806749:AAHycjD4JaEckAHEeqI8Pdt-WkRbc6FGusY",
                        new TelegramBotClient("5311806749:AAHycjD4JaEckAHEeqI8Pdt-WkRbc6FGusY"));

            foreach(var client in clients)
            {
                client.Value.OnMessage += OnMessageHandler;
                client.Value.StartReceiving();
            }

            SendMessage(clients["5421635572:AAHLXcXKIAKzITLa82YDLUTxf9u1CsXpESo"], "896557682", "123");
            SendMessage(clients["5311806749:AAHycjD4JaEckAHEeqI8Pdt-WkRbc6FGusY"], "896557682", "456");

            Console.ReadKey();
            foreach (var client in clients)
            {
                client.Value.StopReceiving();
            }
        }

        private static void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                Console.WriteLine($"Пришло сообщение: {e.Message.Chat.Id} {msg.Text}");
            }
        }

        private static void SendMessage(TelegramBotClient client, string contactId, string message)
        {
            //TelegramBotClient _botClient = new TelegramBotClient(Token);

            var chatId = new global::Telegram.Bot.Types.ChatId(contactId);

            client.SendTextMessageAsync(chatId, message);
        }

    }
}
