using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Receiver.Core;

namespace Telegram.Receiver.Core
{
    public class TelegramReceiver : IReceiver
    {
        private TelegramBotClient _botClient;

        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public TelegramReceiver(string token)//, IWebProxy proxy = null)
        {
            //_botClient = new TelegramBotClient(token, proxy);
            _botClient = new TelegramBotClient(token);
        }

        public void Run()
        {
            _botClient.OnMessage += OnMessageReceived;
            _botClient.StartReceiving();
        }

        public void Stop()
        {
            _botClient.StopReceiving();
        }

        private void OnMessageReceived(object sender, MessageEventArgs e)
        {
            MessageReceived?.Invoke(this,
                                    new MessageReceivedEventArgs()
                                    {
                                        Message = e.Message.Text,
                                        ContactId = e.Message.Chat.Id.ToString()
                                    });
        }
    }
}
