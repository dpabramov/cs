using MedService.Core;

namespace MedService.Telegram.Client
{
    public class TelegramBotCreator : BotCreator
    {
        public override IMedServiceBot FactoryMethod(string token)
        {
            return new MedServiceTelegramBotClient(token);
        }
    }
}
