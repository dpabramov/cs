using MihaZupan;
using System;
using System.Net;
using Telegram.Bot;

namespace TelegramBot
{
    class Program
    {
        private static string token = "5311806749:AAHycjD4JaEckAHEeqI8Pdt-WkRbc6FGusY";

        private static string chatId = "896557682";

        private static TelegramBotClient client;

        static void Main(string[] args)
        {
            Console.WriteLine("Старт Telegram_Bot");
            client = new TelegramBotClient(token);
            client.OnMessage += Client_OnMessage;
            client.StartReceiving();

            client.SendTextMessageAsync(chatId, "Я супер-пупер бот!");

            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
            client.StopReceiving();

        }

        private static void Client_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var msg = e.Message;

            if (msg.Text != null)
                Console.WriteLine($"ChatId: {msg.Chat.Id}\tText: {msg.Text}");

        }

    }
}
