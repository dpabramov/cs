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
            ReminderItem reminderItem = new ReminderItem(
                                        Guid.Parse("B0740FE1-6DC8-434B-BA08-AD61AED91226"),
                                        DateTimeOffset.Parse("2022-04-22 12:31:04"),
                                        "�������� �����",
                                        "ADS456N",
                                        ReminderItemStatus.Failed);

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
            Guid guid = Guid.Parse("B0740FE1-6DC8-434B-BA08-AD61AED91226");
            InMemoryReminderStorage irs = new InMemoryReminderStorage();
            ReminderItem reminderItem = new ReminderItem(   guid,
                                                            DateTimeOffset.Parse("2022-04-22 12:31:04"),
                                                            "�������� �����",
                                                            "ADS456N",
                                                            ReminderItemStatus.Failed);

            //do test
            irs.Add(reminderItem);

            //check
            Assert.IsNotNull(irs.Get(reminderItem.Id));
            Assert.AreEqual(guid, irs.Get(reminderItem.Id).Id);
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
            Guid guid = Guid.Parse("B0740FE1-6DC8-434B-BA08-AD61AED91227");
            ReminderItem reminderItem = new ReminderItem(guid,
                                                        DateTimeOffset.Parse("2022-04-22 12:31:04"),
                                                        "�������� �����",
                                                        "ADS456N",
                                                        ReminderItemStatus.Awaiting);
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
            Guid guid1 = Guid.Parse("B0740FE1-6DC8-434B-BA08-AD61AED91228");
            Guid guid2 = Guid.Parse("B0740FE1-6DC8-434B-BA08-AD61AED91229");
            Guid guid3 = Guid.Parse("B0740FE1-6DC8-434B-BA08-AD61AED91220");
            ReminderItem reminderItem = new ReminderItem(guid1, 
                                                        DateTimeOffset.Parse("2022-04-22 12:31:04"),
                                                        "�������� �����",
                                                        "ADS456N",
                                                        ReminderItemStatus.Awaiting);

            ReminderItem reminderItem2 = new ReminderItem(guid2,
                                                        DateTimeOffset.Parse("2022-04-23 12:31:04"),
                                                        "������� � ����",
                                                        "BDS456N",
                                                        ReminderItemStatus.Awaiting);

            ReminderItem reminderItem3 = new ReminderItem(guid3,
                                                            DateTimeOffset.Parse("2022-04-24 12:31:04"),
                                                            "����������",
                                                            "CDS456N",
                                                            ReminderItemStatus.Awaiting);
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
