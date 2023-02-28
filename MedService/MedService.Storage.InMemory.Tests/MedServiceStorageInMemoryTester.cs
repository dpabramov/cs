using MedService.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MedService.Storage.InMemory.Tests
{
    [TestClass]
    public class MedServiceStorageInMemoryTester
    {
        private InMemoryMedServiceStorage _storage = new InMemoryMedServiceStorage();

        [TestInitialize]
        public void ClearInMemoryMedServiceStorage()
        {
            _storage._doctors.Clear();
            _storage._orders.Clear();
            _storage._sickers.Clear();
            _storage._serviceItems.Clear();
        }

        [TestMethod]
        public void MethodGetSickerReturnsCorrectObject()
        {
            //prepare
            Sicker sicker = new Sicker()
            {
                Id = Guid.NewGuid(),
                Name = "Баба Люба",
                HomeAddress = "г.Волгоград, ул. Коммунистическая 42 кв.53",
                Telephone = "9859550102"
            };
            _storage._sickers.Add(sicker.Id, sicker);

            //do test
            Sicker result = _storage.GetSicker(sicker.Id);
            Sicker result2 = _storage.GetSicker(Guid.NewGuid());

            //check
            Assert.AreEqual(sicker.Id, result.Id);
            Assert.AreEqual(sicker.Name, result.Name);
            Assert.AreEqual(sicker.HomeAddress, result.HomeAddress);
            Assert.AreEqual(sicker.Telephone, result.Telephone);
            Assert.IsNull(result2);
        }

        [TestMethod]
        public void MethodAddSickerAddCorrectObject()
        {
            Sicker addedSicker = _storage.AddSicker("Баба Тая",
                                "г.Волгоград, ул. Козловская 12 кв.17",
                                "9859550103",
                                "Описание",
                                "896557682",
                                "5311806749:AAHycjD4JaEckAHEeqI8Pdt-WkRbc6FGusY"
                                );

            Sicker result = _storage.GetSicker(addedSicker.Id);

            Assert.AreEqual(result.Id, addedSicker.Id);
            Assert.AreEqual(result.Name, addedSicker.Name);
            Assert.AreEqual(result.HomeAddress, addedSicker.HomeAddress);
            Assert.AreEqual(result.Telephone, addedSicker.Telephone);
            Assert.AreEqual(result.Description, addedSicker.Description);
            Assert.AreEqual(result.ContactId, addedSicker.ContactId);
            Assert.AreEqual(result.Token, addedSicker.Token);
        }

        [TestMethod]
        public void MethodUpdateSickerCorrect()
        {
            Sicker addedSicker = _storage.AddSicker("Деда Вася",
                                "г.Москва, ул. Козловская 12 кв.17",
                                "9859550104",
                                "Описание",
                                "896557682",
                                "5311806749:AAHycjD4JaEckAHEeqI8Pdt-WkRbc6FGusY");

            _storage.UpdateSicker(addedSicker.Id,
                new Sicker()
                {
                    Name = "Деда Петя",
                    HomeAddress = "г.Волгоград, ул. Козловская 12 кв.17",
                    Telephone = "9859550104",
                    Description = "Описание 2",
                    ContactId = "123456",
                  Token = "5311806749:AAHycjD4JaEckAHEeqI8Pdt-WkRbc6FGusY1"
                });

            Sicker res = _storage.GetSicker(addedSicker.Id);

            Assert.AreEqual(addedSicker.Id, res.Id);
            Assert.AreEqual("Деда Петя", res.Name);
            Assert.AreEqual("г.Волгоград, ул. Козловская 12 кв.17", res.HomeAddress);
            Assert.AreEqual("9859550104", res.Telephone);
            Assert.AreEqual("Описание 2", res.Description);
            Assert.AreEqual("123456", res.ContactId);
            Assert.AreEqual("5311806749:AAHycjD4JaEckAHEeqI8Pdt-WkRbc6FGusY1", res.Token);
        }

        [TestMethod]
        public void MethodDeleteSickerCorrect()
        {
            Sicker addedSicker = _storage.AddSicker("Деда Вася",
                                "г.Москва, ул. Козловская 12 кв.17",
                                "9859550104",
                                "Описание",
                                "896557682",
                                "5311806749:AAHycjD4JaEckAHEeqI8Pdt-WkRbc6FGusY");


            _storage.DeleteSicker(addedSicker.Id);

            Assert.IsNull(_storage.GetSicker(addedSicker.Id));
        }

        [TestMethod]
        public void MethodGetDoctorCorrect()
        {
            //prepare
            Doctor doctor = new Doctor()
            {
                Id = Guid.NewGuid(),
                Name = "Деда Вася",
                HomeAddress = "г.Москва, ул. Козловская 12 кв.17",
                Telephone = "9859550104",
                Description = "Описание доктора"
            };
            _storage._doctors.Add(doctor.Id, doctor);

            //do
            var res = _storage.GetDoctor(doctor.Id);

            //check
            Assert.AreEqual(doctor.Id, res.Id);
            Assert.AreEqual(doctor.Name, res.Name);
            Assert.AreEqual(doctor.HomeAddress, res.HomeAddress);
            Assert.AreEqual(doctor.Telephone, res.Telephone);
            Assert.AreEqual(doctor.Description, res.Description);
        }

        [TestMethod]
        public void MethodAddDoctorCorrect()
        {
            //prepare

            //do
            Doctor doctor = _storage.AddDoctor("Деда Вася",
                                   "г.Москва, ул. Козловская 12 кв.17",
                                    "9859550104",
                                    "Описание доктора",
                                    "896557682",
                                    "5421635572:AAHLXcXKIAKzITLa82YDLUTxf9u1CsXpESo");

            var res = _storage.GetDoctor(doctor.Id);

            //check
            Assert.AreEqual(doctor.Id, res.Id);
            Assert.AreEqual(doctor.Name, res.Name);
            Assert.AreEqual(doctor.HomeAddress, res.HomeAddress);
            Assert.AreEqual(doctor.Telephone, res.Telephone);
            Assert.AreEqual(doctor.Description, res.Description);
            Assert.AreEqual(doctor.Token, res.Token);
            Assert.AreEqual(doctor.ContactId, res.ContactId);
        }

        [TestMethod]
        public void MethodUpdateDoctorCorrect()
        {
            //prepare
            Doctor doctor = _storage.AddDoctor("Деда Вася",
                                   "г.Москва, ул. Козловская 12 кв.17",
                                    "9859550104",
                                    "Описание доктора",
                                    "896557682",
                                    "5421635572:AAHLXcXKIAKzITLa82YDLUTxf9u1CsXpESo");
            Doctor updatedDoctor = new Doctor()
            {
                Id = Guid.NewGuid(),
                Name = "Абрамов Павел",
                HomeAddress = "г.Волгоград, ул. Елисеева 78 кв.99",
                Description = "Начинающий, но способный врач",
                Telephone = "9859550101",
                ContactId = "896557683",
                Token = "5421635572:AAHLXcXKIAKzITLa82YDLUTxf9u1CsXpES1"
            };

            //do
            _storage.UpdateDoctor(doctor.Id, updatedDoctor);
            var res = _storage.GetDoctor(doctor.Id);

            //check
            Assert.AreEqual(doctor.Id, res.Id);
            Assert.AreEqual(doctor.Name, res.Name);
            Assert.AreEqual(doctor.HomeAddress, res.HomeAddress);
            Assert.AreEqual(doctor.Telephone, res.Telephone);
            Assert.AreEqual(doctor.Description, res.Description);
            Assert.AreEqual(doctor.ContactId, res.ContactId);
            Assert.AreEqual(doctor.Token, res.Token);
        }

        [TestMethod]
        public void MethodDeleteDoctorCorrect()
        {
            //prepare
            Doctor doctor = _storage.AddDoctor("Деда Вася",
                                   "г.Москва, ул. Козловская 12 кв.17",
                                    "9859550104",
                                    "Описание доктора",
                                    "896557682",
                                    "5421635572:AAHLXcXKIAKzITLa82YDLUTxf9u1CsXpESo");

            //do
            _storage.DeleteDoctor(doctor.Id);

            //check
            Assert.IsNull(_storage.GetDoctor(doctor.Id));

        }

        [TestMethod]
        public void MethodGetServiceItemCorrect()
        {
            //prepare
            ServiceItem serviceItem = new ServiceItem()
            {
                Id = Guid.NewGuid(),
                Name = "Поставить капельницу",
                Price = 100.50m,
                Description = "Препарат такой-то"
            };
            _storage._serviceItems.Add(serviceItem.Id, serviceItem);

            //do
            var res = _storage.GetServiceItem(serviceItem.Id);

            //check
            Assert.AreEqual(serviceItem.Id, res.Id);
            Assert.AreEqual(serviceItem.Name, res.Name);
            Assert.AreEqual(serviceItem.Price, res.Price);
            Assert.AreEqual(serviceItem.Description, res.Description);

        }

        [TestMethod]
        public void MethodAddServiceItemCorrect()
        {
            //prepare

            //do
            var addedserviceItem = _storage.AddServiceItem("Поставить капельницу",
                                            100.50m,
                                            "Препарат такой-то");

            //check
            var res = _storage.GetServiceItem(addedserviceItem.Id);
            Assert.AreEqual(addedserviceItem.Id, res.Id);
            Assert.AreEqual(addedserviceItem.Name, res.Name);
            Assert.AreEqual(addedserviceItem.Price, res.Price);
            Assert.AreEqual(addedserviceItem.Description, res.Description);

        }

        [TestMethod]
        public void MethodUpdateServiceItemCorrect()
        {
            //prepare
            var addedserviceItem = _storage.AddServiceItem("Поставить капельницу",
                                            100.50m,
                                            "Препарат такой-то");

            var newItem = new ServiceItem()
            {
                Id = Guid.NewGuid(),
                Name = "Перевязка",
                Price = 125.50m,
                Description = "Сильный порез правой ноги"
            };

            //do
            _storage.UpdateServiceItem(addedserviceItem.Id, newItem);

            //check
            var res = _storage.GetServiceItem(addedserviceItem.Id);
            Assert.AreEqual(addedserviceItem.Id, res.Id);
            Assert.AreEqual(newItem.Name, res.Name);
            Assert.AreEqual(newItem.Price, res.Price);
            Assert.AreEqual(newItem.Description, res.Description);

        }

        [TestMethod]
        public void MethodDeleteServiceItemCorrect()
        {
            //prepare
            var addedserviceItem = _storage.AddServiceItem("Поставить капельницу",
                                            100.50m,
                                            "Препарат такой-то");

            //do
            _storage.DeleteServiceItem(addedserviceItem.Id);

            //check

            Assert.IsNull(_storage.GetServiceItem(addedserviceItem.Id));
        }

        [TestMethod]
        public void MethodCreateOrdersCorrect()
        {
            //prepare
            var serviceItem1 = _storage.AddServiceItem("Поставить капельницу",
                                            100.50m,
                                            "Препарат такой-то");

            var serviceItem2 = _storage.AddServiceItem("Измерить давление",
                                            100.50m,
                                            "манометр");

            Doctor doctor = _storage.AddDoctor("Деда Вася",
                                   "г.Москва, ул. Козловская 12 кв.17",
                                    "9859550104",
                                    "Описание доктора",
                                    "896557682",
                                    "5421635572:AAHLXcXKIAKzITLa82YDLUTxf9u1CsXpESo");

            Sicker sicker = _storage.AddSicker("Баба Тая",
                               "г.Волгоград, ул. Козловская 12 кв.17",
                               "9859550103",
                               "Описание больного",
                               "896557682",
                               "5421635572:AAHLXcXKIAKzITLa82YDLUTxf9u1CsXpESo");

            //do
            Guid orderId = _storage.CreateOrder(DateTimeOffset.Now,
                                                sicker,
                                                doctor,
                                                MedServiceStatus.Opened,
                                                new List<ServiceItem>
                                                {
                                                    serviceItem1,
                                                    serviceItem2
                                                },
                                                "Описание заказа");
            //check
            Assert.IsTrue(_storage._orders.ContainsKey(orderId));

            Assert.IsNotNull(_storage._orders[orderId].Date);

            Assert.AreEqual(sicker.Id, _storage._orders[orderId].Sicker.Id);
            Assert.AreEqual(sicker.Name, _storage._orders[orderId].Sicker.Name);
            Assert.AreEqual(sicker.HomeAddress, _storage._orders[orderId].Sicker.HomeAddress);
            Assert.AreEqual(sicker.Telephone, _storage._orders[orderId].Sicker.Telephone);

            Assert.AreEqual(doctor.Id, _storage._orders[orderId].Doctor.Id);
            Assert.AreEqual(doctor.Name, _storage._orders[orderId].Doctor.Name);
            Assert.AreEqual(doctor.HomeAddress, _storage._orders[orderId].Doctor.HomeAddress);
            Assert.AreEqual(doctor.Telephone, _storage._orders[orderId].Doctor.Telephone);
            Assert.AreEqual(doctor.Description, _storage._orders[orderId].Doctor.Description);
            Assert.AreEqual(doctor.Token, _storage._orders[orderId].Doctor.Token);
            Assert.AreEqual(doctor.ContactId, _storage._orders[orderId].Doctor.ContactId);

            Assert.AreEqual(MedServiceStatus.Opened, _storage._orders[orderId].Status);

            Assert.AreEqual(2, _storage._orders[orderId].ServiceItems.Count);
            Assert.AreEqual(serviceItem1.Id, _storage._orders[orderId].ServiceItems[0].Id);
            Assert.AreEqual(serviceItem1.Name, _storage._orders[orderId].ServiceItems[0].Name);
            Assert.AreEqual(serviceItem1.Price, _storage._orders[orderId].ServiceItems[0].Price);
            Assert.AreEqual(serviceItem1.Description, _storage._orders[orderId].ServiceItems[0].Description);

            Assert.AreEqual(serviceItem2.Id, _storage._orders[orderId].ServiceItems[1].Id);
            Assert.AreEqual(serviceItem2.Name, _storage._orders[orderId].ServiceItems[1].Name);
            Assert.AreEqual(serviceItem2.Price, _storage._orders[orderId].ServiceItems[1].Price);
            Assert.AreEqual(serviceItem2.Description, _storage._orders[orderId].ServiceItems[1].Description);

            Assert.AreEqual("Описание заказа", _storage._orders[orderId].Description);
        }

        [TestMethod]
        public void MethodGetOrdersByStatusCorrect()
        {
            //prepare
            var serviceItem1 = _storage.AddServiceItem("Поставить капельницу",
                                            100.50m,
                                            "Препарат такой-то");

            var serviceItem2 = _storage.AddServiceItem("Измерить давление",
                                            100.50m,
                                            "манометр");

            Doctor doctor = _storage.AddDoctor("Деда Вася",
                                   "г.Москва, ул. Козловская 12 кв.17",
                                    "9859550104",
                                    "Описание доктора",
                                    "896557682",
                                    "5421635572:AAHLXcXKIAKzITLa82YDLUTxf9u1CsXpESo");

            Sicker sicker = _storage.AddSicker("Баба Тая",
                               "г.Волгоград, ул. Козловская 12 кв.17",
                               "9859550103",
                               "Описание больного",
                               "896557682",
                               "5421635572:AAHLXcXKIAKzITLa82YDLUTxf9u1CsXpESo");

            Guid orderId = _storage.CreateOrder(DateTimeOffset.Now,
                                                sicker,
                                                doctor,
                                                MedServiceStatus.Opened,
                                                new List<ServiceItem>
                                                {
                                                    serviceItem1,
                                                    serviceItem2
                                                },
                                                "Описание заказа");

            Guid orderId1 = _storage.CreateOrder(DateTimeOffset.Now,
                                                sicker,
                                                doctor,
                                                MedServiceStatus.Opened,
                                                new List<ServiceItem>
                                                {
                                                    serviceItem1,
                                                    serviceItem2
                                                },
                                                "Описание второго заказа");


            //do
            List<Order> orders = _storage.GetOrdersByStatus(MedServiceStatus.Opened);
            List<Order> orders1 = _storage.GetOrdersByStatus(MedServiceStatus.Scheduled);

            //check
            Assert.AreEqual(2, orders.Count);
            Assert.AreEqual(0, orders1.Count);
        }
    }
}
