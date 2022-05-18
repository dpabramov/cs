using System;
using System.Net;
using Telegram.Bot;
using Telegram.Bot.Args;
using Reminder.Receiver.Core;

namespace Reminder.Receiver.Telegram
{
    public class TelegramReminderReceiver : IReminderReceiver
    {
        private TelegramBotClient _botClient;

        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public TelegramReminderReceiver(string token)
        {
            _botClient = new TelegramBotClient(token);
        }

        public void Run()
        {
            _botClient.OnMessage += _botClient_OnMessage;
            _botClient.StartReceiving();
        }

        private void _botClient_OnMessage(object sender, MessageEventArgs e)
        {
            //все не текстовые сообщения которые мы отправили в чат не обрабатываем
            if (e.Message.Type != global::Telegram.Bot.Types.Enums.MessageType.Text)
                return;

            //
            MessageReceived?.Invoke(this,
                                    new MessageReceivedEventArgs
                                    {
                                        ContactId = e.Message.Chat.Id.ToString(),
                                        Message = e.Message.Text
                                    });
        }
    }
}
