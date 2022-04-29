using System;
using Telegram.Bot;
using Reminder.Sender.Core;
using System.Net;
using System.Net.Http;

namespace Reminder.Sender.Telegram
{
    public class TelegramReminderSender : IReminderSender
    {
        private TelegramBotClient _botClient;

        public TelegramReminderSender(string token)//, IWebProxy proxy = null)
        {
            _botClient = new TelegramBotClient(token);//, proxy);
        }

        public void Send(string contactId, string message)
        {
            var chatId = new global::Telegram.Bot.Types.ChatId(contactId);

            _botClient.SendTextMessageAsync(chatId, message);
        }
    }
}
