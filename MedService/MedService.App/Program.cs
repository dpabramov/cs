using MedService.Core;
using MedService.Domain;
using MedService.Storage.InMemory;
using MedService.Telegram.Client;
using System;
using System.Collections.Generic;

namespace MedService.App
{
    class Program
    {
        static void Main(string[] args)
        {
            const string doctorsJsonFile = @"doctors.json";

            const string sickersJsonFile = @"sickers.json";

            IMedServiceStorage ims = new InMemoryMedServiceStorage();

            TelegramBotCreator telegramBotCreator = new TelegramBotCreator();
            
            //создаем больного
            //ModelSickerImport modelSickerImport = new ModelSickerImport()
            //{
            //    Name = "Больной Пупкин",
            //    HomeAddress = "Возле МКАДа",
            //    Telephone = "9859850000",
            //    Description = "Описание больного",
            //    ContactId = "896557682",
            //    Token = "5311806749:AAHycjD4JaEckAHEeqI8Pdt-WkRbc6FGusY"
            //};

            ////записываем больного в файл
            //JsonFileReader.WriteSickersToJsonFile(sickersJsonFile,
            //                            new List<ModelSickerImport>() { modelSickerImport });

            //создаем доктора
            //ModelDoctorImport doctor = new ModelDoctorImport()
            //{
            //    Name = "Хирург Паша",
            //    HomeAddress = "Испанский квартал",
            //    Telephone = "9859850000",
            //    ContactId = "896557682",
            //    Description = "Крутой доктор",
            //    Token = "5421635572:AAHLXcXKIAKzITLa82YDLUTxf9u1CsXpESo"
            //};

            //записываем его в файл
            //JsonFileReader.WriteDoctorsToJsonFile(doctorsJsonFile,
            //                                new List<ModelDoctorImport>() { doctor });

            //Считываем список больных из файла
            List<ModelSickerImport> modelSickerImports = JsonFileReader
                                        .ReadSickersFromJsonFile(sickersJsonFile);

            //... и пишем его в хранилище
            modelSickerImports.ForEach(s => ims.AddSicker(telegramBotCreator.FactoryMethod(s.Token),
                                                    s.Name,
                                                    s.HomeAddress,
                                                    s.Telephone,
                                                    s.Description,
                                                    s.ContactId,
                                                    s.Token));

            //Считываем список докторов из файла 
            List<ModelDoctorImport> modelDoctorImports = JsonFileReader
                                        .ReadDoctorsFromJsonFile(doctorsJsonFile);

            //... и пишем его в хранилище
            modelDoctorImports.ForEach(d => ims.AddDoctor(telegramBotCreator.FactoryMethod(d.Token),
                                            d.Name,
                                            d.HomeAddress,
                                            d.Telephone,
                                            d.Description,
                                            d.ContactId,
                                            d.Token));

            MedServiceDomain domain = new MedServiceDomain(ims,
                                            TimeSpan.FromSeconds(30),
                                            TimeSpan.FromSeconds(30));

            domain.Run();

            ims.GetAllSickers().ForEach(
                s => s.BotClient.Send(s.ContactId, $"Приветствуем больного {s.Name}"));

            ims.GetAllSickers().ForEach(
                s => s.BotClient.Send(s.ContactId, $"Для создания наряда наберите следущую команду:"));

            ims.GetAllSickers().ForEach(
                s => s.BotClient.Send(s.ContactId, $"Новый заказ"));

            ims.GetAllDoctors().ForEach(
                s => s.BotClient.Send(s.ContactId, $"Приветствуем врача {s.Name}"));

            Console.WriteLine("Для завершения нажмите любую кнопку");
            Console.ReadKey();

            domain.Stop();
        }
    }
}
