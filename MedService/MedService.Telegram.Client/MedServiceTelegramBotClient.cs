using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using MedService.Core;

namespace MedService.Telegram.Client
{
    public class MedServiceTelegramBotClient : IMedServiceBot
    {
        private TelegramBotClient _botClient;

        private OrderCreatedEventArgs _order;

        public string Token { get; set; }

        public event EventHandler<OrderCreatedEventArgs> OrderCreated;

        public MedServiceTelegramBotClient(string token)
        {
            Token = token;

            _botClient = new TelegramBotClient(Token);
        }

        public void Send(string contactId, string message)
        {
            var chatId = new ChatId(contactId);

            _botClient.SendTextMessageAsync(chatId, message);
        }

        public void StartReceiving()
        {
            _botClient.StartReceiving(Update, Error);
        }

        private Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }

        async private Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;

            if (message.Text == null)
                return;

            if (message.Text == MedServiceMessages.NewOrder)
            {
                CreateNewOrder(botClient, message.Chat.Id);
                return;
            }

            if (message.Text.Contains(MedServiceMessages.prefixInputDate))
            {
                FillInOrderDate(botClient, message.Chat.Id, message.Text);
                return;
            }

            if (message.Text.Contains(MedServiceMessages.prefixInputServiceItem))
            {
                FillInServiceItem(botClient, message.Chat.Id, message.Text);
                return;
            }

            if (message.Text.Contains(MedServiceMessages.PrefixInputDescription))
            {
                FillInDescription(botClient, message.Chat.Id, message.Text);
                return;
            }

        }

        async private void FillInDescription(ITelegramBotClient botClient, long id, string message)
        {
            if (_order == null)
            {
                await botClient.SendTextMessageAsync(id,
                    MedServiceMessages.NewOrderIsNullErrorMessage);

                return;
            }

            int lengthText = MedServiceMessages.PrefixInputDescription.Length;
            string text = message.Substring(lengthText, (message.Length - lengthText));
            await botClient.SendTextMessageAsync(id,
                MedServiceMessages.Ok);

            _order.Description = text;

            OrderCreated?.Invoke(this, _order);
        }

        async private void FillInServiceItem(ITelegramBotClient botClient, long id, string message)
        {
            if (_order == null)
            {
                await botClient.SendTextMessageAsync(id,
                    MedServiceMessages.NewOrderIsNullErrorMessage);

                return;
            }

            int lengthMessage = MedServiceMessages.prefixInputServiceItem.Length;
            string text = message.Substring(lengthMessage, (message.Length - lengthMessage));
            await botClient.SendTextMessageAsync(id, MedServiceMessages.Ok);

            _order.ServiceItems.Add(new ServiceItem()
                                        {
                                            Name = text
                                        });

            await botClient.SendTextMessageAsync(id,
                    MedServiceMessages.NextServiceItemMessage);

            await botClient.SendTextMessageAsync(id,
                MedServiceMessages.ExampleDescriptionMessage);
        }

        async private void FillInOrderDate(ITelegramBotClient botClient, long id, string message)
        {
            if (_order == null)
            {
                await botClient.SendTextMessageAsync(id,
                                        MedServiceMessages.NewOrderIsNullErrorMessage);
                return;
            }

            int lengthPrefix = MedServiceMessages.prefixInputDate.Length;

            if (IsDate(message.Substring(lengthPrefix, (message.Length - lengthPrefix)), out DateTimeOffset date))
            {
                await botClient.SendTextMessageAsync(id, MedServiceMessages.Ok);
                _order.Date = date;

                await botClient.SendTextMessageAsync(id,
                    MedServiceMessages.EnterServiceItemMessage);

                await botClient.SendTextMessageAsync(id,
                    MedServiceMessages.ExampleBelowMessage);

                await botClient.SendTextMessageAsync(id,
                    MedServiceMessages.ExampleServiceItemMessage);
            }
            else
            {
                await botClient.SendTextMessageAsync(id, MedServiceMessages.UnCorrectDateMessage);
            }
        }

        async private void CreateNewOrder(ITelegramBotClient botClient, long id)
        {
            _order = new OrderCreatedEventArgs
            {
                Status = MedServiceStatus.Opened,

                ContactId = id.ToString()
            };

            await botClient.SendTextMessageAsync(id,
                MedServiceMessages.NewOrderInputMessage);

            await botClient.SendTextMessageAsync(id,
                MedServiceMessages.ExampleDate);
        }

        private bool IsDate(string text, out DateTimeOffset date)
        {
            return DateTimeOffset.TryParse(text, out date);
        }
    }
}
