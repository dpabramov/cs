using System;
using System.Collections.Generic;
using MedService.Core;
using MedService.Receiver.Core;
using MedService.Receiver.Telegram;
using MedService.Sender.Core;
using MedService.Sender.Telegram;
using MedService.Storage.InMemory;
using MedService.Telegram.Client;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace MedService.Domain.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            IMedServiceStorage ims = new InMemoryMedServiceStorage();

            //ServiceItem service1 = ims.AddServiceItem("Поставить капельницу", 50.3m, "То-то и то-то");

            //ServiceItem service2 = ims.AddServiceItem("Сделать перевязку", 40.3m, " Перевязка там-то");

            //List<ServiceItem> services = new List<ServiceItem>
            //    {
            //        service1,
            //        service2
            //    };

           Sicker sicker1 = ims.AddSicker(
                            new MedServiceTelegramBotClient(
                                    "5311806749:AAHycjD4JaEckAHEeqI8Pdt-WkRbc6FGusY"),
                            "Больной Соколов",
                            "Живу на МКАДе",
                            "1111111111",
                            "Описание Соколов",
                            "896557682",
                            "5311806749:AAHycjD4JaEckAHEeqI8Pdt-WkRbc6FGusY");

            Sicker sicker2 = ims.AddSicker(
                            new MedServiceTelegramBotClient(
                                    "5421635572:AAHLXcXKIAKzITLa82YDLUTxf9u1CsXpESo"),
                            "Больной Червериков",
                            "Живу за МКАДом",
                            "2222222222",
                            "Описание Червериков",
                            "896557682",
                            "5421635572:AAHLXcXKIAKzITLa82YDLUTxf9u1CsXpESo");

            //var orderId = ims.CreateOrder(DateTimeOffset.Now,
            //                                sicker1,
            //                                null,
            //                                MedServiceStatus.Opened,
            //                                services,
            //                                "Просто заказ");

            //var orderId1 = ims.CreateOrder(DateTimeOffset.Now,
            //                    sicker2,
            //                    null,
            //                    MedServiceStatus.Opened,
            //                    services,
            //                    "Просто заказ");

            //var orderId2 = ims.CreateOrder(DateTimeOffset.Now,
            //        sicker1,
            //        null,
            //        MedServiceStatus.Opened,
            //        services,
            //        "Просто заказ");



            MedServiceDomain domain = new MedServiceDomain(ims,
                                        TimeSpan.FromSeconds(30),
                                        TimeSpan.FromMinutes(1));

            domain.OrderScheduled += OnOrderScheduled;

            domain.OrderDistributed += OnOrderDistribute;

            domain.MedServiceMessageReceived += OnMedServiceMessageReceived;

            domain.Run();

            //senders.Find(s => s.Token == "5421635572:AAHLXcXKIAKzITLa82YDLUTxf9u1CsXpESo")
            //      .Send("896557682", "отправляем текст 1");

            //senders.Find(s => s.Token == "5311806749:AAHycjD4JaEckAHEeqI8Pdt-WkRbc6FGusY")
            //        .Send("896557682", "отправляем текст 2");

            //Doctor doctor1 = ims.AddDoctor("Абрамов Павел",
            //                                "г.Волгоград, Коммунистическая 15",
            //                                "9859850000",
            //                                "Крутой доктор",
            //                                "896557682",
            //                                "5421635572:AAHLXcXKIAKzITLa82YDLUTxf9u1CsXpESo");

            //Doctor doctor2 = ims.AddDoctor("Иванов Иван",
            //                                "г.Волгоград, Коммунистическая 23",
            //                                "9859850999",
            //                                "Тоже крут",
            //                                "896557682",
            //                                "5311806749:AAHycjD4JaEckAHEeqI8Pdt-WkRbc6FGusY");

            Console.ReadKey();

            domain.Stop();
        }

        private static void OnDoctorAdded(object sender, DoctorAddedEventArgs e)
        {
            Console.WriteLine($"Добавлен доктор: {e.Id}" +
                $"\n{e.HomeAddress}" +
                $"\n{e.Name}" +
                $"\n{e.Telephone}" +
                $"\n{e.Token}" +
                $"\n{e.Description}" +
                $"\n{e.ContactId}");
        }

        private static void OnMedServiceMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine($"От {e.ContactId} получено сообщение: {e.Message}");
        }

        private static void OnOrderDistribute(object sender, ToDistributeEventArgs e)
        {
            Console.WriteLine($"Наряд {e.OrderGuid} изменен: Статус {e.status}");
        }

        private static void OnOrderScheduled(object sender, ToScheduleEventArgs e)
        {
            Console.WriteLine($"Наряд {e.OrderGuid} запланирован: Доктор {e.doctor.Name}, Статус {e.status}");
        }
    }
}
