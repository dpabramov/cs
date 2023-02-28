using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramExample3
{
    class Program
    {
        static Order order = new Order();

        static void Main(string[] args)
        {
            string token = "5421635572:AAHLXcXKIAKzITLa82YDLUTxf9u1CsXpESo";

            var client = new TelegramBotClient(token);

            client.StartReceiving(Update, Error);

            Console.WriteLine("Для завершения нажмите любую клавишу");
            Console.ReadKey();
        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            Order order = new Order();

            var message = update.Message;

            if (message.Text != null)
            {
                if (message.Text.ToLower() == "новый заказ")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id,
                        "Для ввода нового заказа введите обязательные сведения. \n" +
                        "Ниже пример:");

                    await botClient.SendTextMessageAsync(message.Chat.Id,
                        "Дата и время заказа: 2022-10-21 13:00");

                    await botClient.SendTextMessageAsync(message.Chat.Id,
                        "Адрес: г.Город, ул. Ленина 1, кв.1");

                    await botClient.SendTextMessageAsync(message.Chat.Id,
                        "Услуга: Поставить капельницу");

                    return;
                }

                if (message.Text.ToLower().Contains("дата и время заказа:"))
                {
                    DateTimeOffset date;
                    if (isDate(message.Text.Substring(21, (message.Text.Length - 21)), out date))
                    {
                        await botClient.SendTextMessageAsync(message.Chat.Id,
                                                            $"Введена корректная дата {date}");
                        order.Date = date;
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Некорректный ввод, введите дату:");
                    }
                }

                if (message.Text.ToLower().Contains("адрес:"))
                {
                    string address = message.Text.Substring(7, (message.Text.Length - 7));
                    await botClient.SendTextMessageAsync(message.Chat.Id,
                        $"Введен корректный адрес {address}");

                    order.Address = address;
                }
            }
        }

        private static bool isDate(string text, out DateTimeOffset date)
        {
            return DateTimeOffset.TryParse(text, out date);
        }

    }

    class Order
    {
        public DateTimeOffset Date { get; set; }

        public string Address { get; set; }

        public string Service { get; set; }
    }
}
