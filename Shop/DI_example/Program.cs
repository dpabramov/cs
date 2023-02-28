using System;
using Microsoft.Extensions.DependencyInjection;

namespace DI_example
{
    class Program
    {
        

        static void Main(string[] args)
        {
            //задаем соответствие интерфейсов и классов
            IServiceCollection services = new ServiceCollection()
            .AddTransient<ILogger, SimpleLogServiceGreen>()
            .AddTransient<Logger>();

            //получаем провайдера из которого далее будем получать нужные классы
            var serviceProvider = services.BuildServiceProvider();

            Logger logger = serviceProvider.GetService<Logger>();

            logger.Log("Hello World!!!");

            Console.WriteLine("Для завершения нажмите любую клавишу");

            Console.ReadKey();
        }
    }
}
