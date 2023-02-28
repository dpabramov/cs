using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Threading;

namespace TelegramExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            //TelegramWorker telegramWorker = new TelegramWorker();

            //telegramWorker.Run();

            //Thread.Sleep(3000);

            //telegramWorker.SendMessage("Ты крутой программер");

            string contactId = "896557682";

            TelegramWorker telegramWorker = new TelegramWorker();

            telegramWorker.OnMessageReceived += OnMessageReceived_telegramWorker;

            telegramWorker.OnMessageSent += OnMessageSent_telegramWorker;

            telegramWorker.Run();

            for(int i = 0; i < 10; i++)
            {
                telegramWorker.Send(contactId, $"{i * 100}");
                Thread.Sleep(10000);
            }

            Console.ReadKey();
        }

        private static void OnMessageSent_telegramWorker(object sender, MessageSentEventArgs e)
        {
            Console.WriteLine($"Отправлено сообщение: {e.ContactId}\t{e.Message} ");
        }

        private static void OnMessageReceived_telegramWorker(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine($"Пришло сообщение: {e.ContactId}\t{e.Message} ");
        }
    }
}
