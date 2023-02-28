using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramExample
{
    class TelegramWorker
    {
        private TelegramBotClient _botClient;

        public event EventHandler<MessageReceivedEventArgs> OnMessageReceived;

        public event EventHandler<MessageSentEventArgs> OnMessageSent;

        public TelegramWorker(string token = "5311806749:AAHycjD4JaEckAHEeqI8Pdt-WkRbc6FGusY")
        {
            _botClient = new TelegramBotClient(token);
        }

        public void Run()
        {
            _botClient.OnMessage += OnMessageBotClient;
            _botClient.StartReceiving();
        }

        private void OnMessageBotClient(object sender, MessageEventArgs e)
        {
            OnMessageReceived?.Invoke(this,
                                      new MessageReceivedEventArgs
                                      {
                                          ContactId = e.Message.Chat.Id.ToString(),
                                          Message = e.Message.Text
                                      });
        }

        public void Send(string contactId, string message)
        {
            //берем из библиотеки подключенной к проекту
            var chatId = new global::Telegram.Bot.Types.ChatId(contactId);

            _botClient.SendTextMessageAsync(chatId, message);

            OnMessageSent?.Invoke(this,
                                    new MessageSentEventArgs
                                    {
                                        ContactId = contactId,
                                        Message = message
                                    });
        }
    }
}
