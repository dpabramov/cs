using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Domain.Models;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;

namespace Reminder.Domain.Test
{
    [TestClass]
    public class UnitTest1
    {
        bool isReadyStatus = false;
        bool isSentStatus = false;
        bool isFaultStatus = false;

        [TestMethod]
        public void Method_Run_Update_Status_To_Ready()
        {
            ReminderItem reminderItem = new ReminderItem(DateTimeOffset.Now, null, null);
            InMemoryReminderStorage inMemoryReminderStorage = new InMemoryReminderStorage();
            inMemoryReminderStorage.Add(reminderItem);

            //т.к. класс ReminderDomain наследует от IDisposable
            using (ReminderDomain reminderDomain = new ReminderDomain(inMemoryReminderStorage))
            {
                //подписываемся на событие, метод задаем в виде лямбды
                reminderDomain.StatusChangedToReady += 
                    (Object sender, StatusChangedToReadyEventArgs args) => isReadyStatus = true;

                reminderDomain.Run();
                //паузу делаем чтобы отработали методы по первому таймеру
                //и не обработали по второму таймеру
                System.Threading.Thread.Sleep(5000);
            }

            //проверяем
            Assert.AreEqual(true, isReadyStatus);
        }

        [TestMethod]
        public void Method_Run_Send_Message_And__Update_Status_To_Sent()
        {

            ReminderItem reminderItem = new ReminderItem(DateTimeOffset.Now, null, null);
            InMemoryReminderStorage inMemoryReminderStorage = new InMemoryReminderStorage();
            inMemoryReminderStorage.Add(reminderItem);

            //т.к. класс ReminderDomain наследует от IDisposable
            using (ReminderDomain reminderDomain = new ReminderDomain(inMemoryReminderStorage))
            {
                reminderDomain.SendReminder += OnSendReminder;
                reminderDomain.SendingSucceeded += (Object sender, SendingSucceededEventArgs e) => isSentStatus = true;

                reminderDomain.Run();
                //паузу делаем чтобы отработали методы по первому таймеру
                //и не обработали по второму таймеру
                System.Threading.Thread.Sleep(5000);
            }

            Assert.AreEqual(true, isSentStatus);
            Assert.AreEqual(ReminderItemStatus.Sent, reminderItem.Status);

        }

        private void OnSendReminder(ReminderItem obj)
        {
        }

        [TestMethod]
        public void Method_Run_Send_Message_And__Update_Status_To_Faulure()
        {
            ReminderItem reminderItem = new ReminderItem(DateTimeOffset.Now, null, null);
            InMemoryReminderStorage inMemoryReminderStorage = new InMemoryReminderStorage();
            inMemoryReminderStorage.Add(reminderItem);

            //т.к. класс ReminderDomain наследует от IDisposable
            using (ReminderDomain reminderDomain = new ReminderDomain(inMemoryReminderStorage))
            {
                reminderDomain.SendReminder += OnSendReminderFailed;
                reminderDomain.SendingFailed += (Object sender, SendingFailedEventArgs e) => isFaultStatus = true;

                reminderDomain.Run();
                //паузу делаем чтобы отработали методы по первому таймеру
                //и не обработали по второму таймеру
                System.Threading.Thread.Sleep(5000);
            }

            Assert.AreEqual(true, isFaultStatus);
            Assert.AreEqual(ReminderItemStatus.Failed, reminderItem.Status);
        }

        private void OnSendReminderFailed(ReminderItem obj)
        {
            throw new Exception();
        }
    }
}
