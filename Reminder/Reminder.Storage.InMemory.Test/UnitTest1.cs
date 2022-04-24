using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using System;
using System.Collections.Generic;

namespace Reminder.Storage.InMemory.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Initialize_Storage_Correctly()
        {
            //prepare
            InMemoryReminderStorage irs = new InMemoryReminderStorage();

            //check
            Assert.IsNotNull(irs);
            Assert.IsNotNull(irs.reminders);
        }

        [TestMethod]
        public void Method_Get_Returns_Correct_Data()
        {
            //prepare
            InMemoryReminderStorage irs = new InMemoryReminderStorage();
            ReminderItem reminderItem = new ReminderItem(DateTimeOffset.Parse("2022-04-22 12:31:04"),
                                                                               "Закапать капли",
                                                                               "ADS456N");

            //do test
            irs.reminders.Add(reminderItem.Id, reminderItem);
            
            //check
            Assert.AreEqual(reminderItem.Id, irs.Get(reminderItem.Id).Id);
            Assert.AreEqual(reminderItem.Date, irs.Get(reminderItem.Id).Date);
            Assert.AreEqual(reminderItem.Message, irs.Get(reminderItem.Id).Message);
            Assert.AreEqual(reminderItem.ContactId, irs.Get(reminderItem.Id).ContactId);
            Assert.AreEqual(reminderItem.Status, irs.Get(reminderItem.Id).Status);
            Assert.IsNull(irs.Get(Guid.NewGuid()));
        }

        [TestMethod]
        public void Method_Add_Writes_Correct_Data()
        {
            //prepare
            InMemoryReminderStorage irs = new InMemoryReminderStorage();
            ReminderItem reminderItem = new ReminderItem(DateTimeOffset.Parse("2022-04-22 12:31:04"),
                                                                               "Закапать капли",
                                                                               "ADS456N");

            //do test
            irs.Add(reminderItem);

            //check
            Assert.IsNotNull(irs.Get(reminderItem.Id));
            Assert.AreEqual(reminderItem.Date, irs.Get(reminderItem.Id).Date);
            Assert.AreEqual(reminderItem.Message, irs.Get(reminderItem.Id).Message);
            Assert.AreEqual(reminderItem.ContactId, irs.Get(reminderItem.Id).ContactId);
            Assert.AreEqual(reminderItem.Status, irs.Get(reminderItem.Id).Status);
        }

        [TestMethod]
        public void Method_Update_Works_Correctly()
        {
            //prepare
            InMemoryReminderStorage irs = new InMemoryReminderStorage();
            ReminderItem reminderItem = new ReminderItem(DateTimeOffset.Parse("2022-04-22 12:31:04"),
                                                                               "Закапать капли",
                                                                               "ADS456N");
            irs.Add(reminderItem);

            //do test
            irs.Update(reminderItem.Id, ReminderItemStatus.Ready);

            //check
            Assert.AreEqual(reminderItem.Id, irs.Get(reminderItem.Id).Id);
            Assert.AreEqual(reminderItem.Date, irs.Get(reminderItem.Id).Date);
            Assert.AreEqual(reminderItem.Message, irs.Get(reminderItem.Id).Message);
            Assert.AreEqual(reminderItem.ContactId, irs.Get(reminderItem.Id).ContactId);
            Assert.AreEqual(ReminderItemStatus.Ready, irs.Get(reminderItem.Id).Status);
        }

        [TestMethod]
        public void Method_GetByStatus_Works_Correctly()
        {
            //prepare
            InMemoryReminderStorage irs = new InMemoryReminderStorage();
            ReminderItem reminderItem = new ReminderItem(DateTimeOffset.Parse("2022-04-22 12:31:04"),
                                                                               "Закапать капли",
                                                                               "ADS456N");

            ReminderItem reminderItem2 = new ReminderItem(DateTimeOffset.Parse("2022-04-23 12:31:04"),
                                                                               "Сходить в кино",
                                                                               "BDS456N");

            ReminderItem reminderItem3 = new ReminderItem(DateTimeOffset.Parse("2022-04-24 12:31:04"),
                                                                   "Тренировка",
                                                                   "CDS456N");
            irs.Add(reminderItem);
            irs.Add(reminderItem2);
            irs.Add(reminderItem3);
            irs.Update(reminderItem.Id, ReminderItemStatus.Ready);

            //do test
            List<ReminderItem> list1 = irs.Get(ReminderItemStatus.Ready);
            List<ReminderItem> list2 = irs.Get(ReminderItemStatus.Awaiting);

            //Check
            Assert.AreEqual(reminderItem.Id, list1[0].Id);
            Assert.AreEqual(ReminderItemStatus.Ready, list1[0].Status);
            Assert.AreEqual(1, list1.Count);
            Assert.AreEqual(2, list2.Count);
            Assert.AreEqual(ReminderItemStatus.Awaiting, list2[0].Status);
            Assert.AreEqual(ReminderItemStatus.Awaiting, list2[1].Status);
        }
    }
}
