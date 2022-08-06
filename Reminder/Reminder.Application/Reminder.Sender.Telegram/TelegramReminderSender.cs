using System;
using Telegram.Bot;
using Reminder.Sender.Core;
using System.Net;
using System.Net.Http;

namespace Reminder.Sender.Telegram
{
    public class TelegramReminderSender : IReminderSender
    {
        //класс, смысл которого - бот отправляет в чат сообщение
        private TelegramBotClient _botClient;

        public TelegramReminderSender(string token)
        {
            _botClient = new TelegramBotClient(token);
        }

        public void Send(string contactId, string message)
        {
            //берем из библиотеки подключенной к проекту
            var chatId = new global::Telegram.Bot.Types.ChatId(contactId);

            _botClient.SendTextMessageAsync(chatId, message);
        }
    }
}
