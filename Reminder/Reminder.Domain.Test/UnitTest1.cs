using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using System;

namespace Reminder.Domain.Test
{
    [TestClass]
    public class UnitTest1
    {
        bool isReadyStatus = false;

        [TestMethod]
        public void Method_Run_Update_Status_To_Ready()
        {

            ReminderItem reminderItem = new ReminderItem(DateTimeOffset.Now, null, null);
            InMemoryReminderStorage inMemoryReminderStorage = new InMemoryReminderStorage();
            inMemoryReminderStorage.Add(reminderItem);

            //т.к. класс ReminderDomain наследует от IDisposable
            using (ReminderDomain reminderDomain = new ReminderDomain(inMemoryReminderStorage))
            {
                reminderDomain.OnSuccessSendMessageEvent += SuccessSendMessageEvent;

                reminderDomain.Run();
                //паузу делаем чтобы отработали методы по первому таймеру
                //и не обработали по второму таймеру
                System.Threading.Thread.Sleep(5000);
            }

            Assert.AreEqual(true, isReadyStatus);



        }

        private void SuccessSendMessageEvent(object sender, EventArgs e)
        {
            isReadyStatus = true;
        }
    }
}
