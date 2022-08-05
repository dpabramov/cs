using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using System;
using System.Collections.Generic;

namespace Reminder.Storage.SqlServer.ADO.Test
{
    [TestClass]
    public class SqlStorageReminderTest
    {
        private readonly string _connectionString =
            @"Data Source=DESKTOP-EU10JJA\SQLEXPRESS; Initial Catalog=RemindersTest; Integrated Security=true";

        [TestInitialize]
        public void TestInitialize()
        {
            new SqlReminderStorageInit(_connectionString).InitializeDatabase();
        }

        [TestMethod]
        public void MethodGetById_Returns_ReminderItem_with_correct_fields()
        {
            var storage = new SqlServerReminderStorage(_connectionString);

            ReminderItem reminder = storage.Get(System.Guid.Parse("00000000-0000-0000-0000-111111111111"));

            Assert.AreEqual(Guid.Parse("00000000-0000-0000-0000-111111111111"), reminder.Id);
            Assert.AreEqual(DateTimeOffset.Parse("2022-09-01 20:00:00.000 +00:00"), reminder.Date);
            Assert.AreEqual("Пора на рыбалку", reminder.Message);
            Assert.AreEqual("contact_1", reminder.ContactId);
            Assert.AreEqual(ReminderItemStatus.Awaiting, reminder.Status);
        }

        [TestMethod]
        public void MethodGetById_Returns_Null_if_guid_not_Present_in_DB()
        {
            var storage = new SqlServerReminderStorage(_connectionString);

            ReminderItem reminder = storage.Get(System.Guid.Parse("10000000-0000-0000-0000-111111111111"));

            Assert.IsNull(reminder);
        }

        [TestMethod]
        public void MethodGetById_Returns_Null_if_guid_is_Null()
        {
            var storage = new SqlServerReminderStorage(_connectionString);

            ReminderItem reminder = storage.Get(Guid.Empty);

            Assert.IsNull(reminder);
        }

        [TestMethod]
        public void Method_Add_returns_correct_guid_and_fillin_properties_correctly()
        {
            var storage = new SqlServerReminderStorage(_connectionString);
            DateTimeOffset dateTimeOffset =
                DateTimeOffset.Parse("2022-09-30 20:00:00.000 +03:00");
            string message = "Проверить работу класса";
            string contactId = "Contact_3";

            Guid guid = storage.Add(dateTimeOffset,
                                   message,
                                   contactId,
                                   ReminderItemStatus.Failed);
            var reminder = storage.Get(guid);

            Assert.IsNotNull(reminder);
            Assert.AreEqual(guid, reminder.Id);
            Assert.AreEqual(dateTimeOffset, reminder.Date);
            Assert.AreEqual(message, reminder.Message);
            Assert.AreEqual(contactId, reminder.ContactId);
            Assert.AreEqual(ReminderItemStatus.Failed, reminder.Status);
        }

        [TestMethod]
        public void Method_GetByStatus_Works_correctly()
        {
            var storage = new SqlServerReminderStorage(_connectionString);

            List<ReminderItem> reminders = storage.Get(ReminderItemStatus.Awaiting);

            Assert.AreEqual(2, reminders.Count);
            Assert.AreEqual(Guid.Parse("00000000-0000-0000-0000-111111111111"), reminders[0].Id);
            Assert.AreEqual(DateTimeOffset.Parse("2022-09-01 20:00:00.000 +00:00"), reminders[0].Date);
            Assert.AreEqual("Пора на рыбалку", reminders[0].Message);
            Assert.AreEqual("contact_1", reminders[0].ContactId);
            Assert.AreEqual(ReminderItemStatus.Awaiting, reminders[0].Status);

            Assert.AreEqual(Guid.Parse("00000000-0000-0000-0000-222222222222"), reminders[1].Id);
            Assert.AreEqual(DateTimeOffset.Parse("2022-09-02 20:00:00.000 +00:00"), reminders[1].Date);
            Assert.AreEqual("Пора заняться программированием", reminders[1].Message);
            Assert.AreEqual("contact_2", reminders[1].ContactId);
            Assert.AreEqual(ReminderItemStatus.Awaiting, reminders[1].Status);

            reminders.Clear();
            reminders = storage.Get(ReminderItemStatus.Sent);
            Assert.AreEqual(1, reminders.Count);
            Assert.AreEqual(Guid.Parse("00000000-0000-0000-0000-555555555555"), reminders[0].Id);
            Assert.AreEqual(DateTimeOffset.Parse("2022-09-05 20:00:00.0000000 +00:00"), reminders[0].Date);
            Assert.AreEqual("Надо погулять", reminders[0].Message);
            Assert.AreEqual("contact_5", reminders[0].ContactId);
            Assert.AreEqual(ReminderItemStatus.Sent, reminders[0].Status);

            reminders.Clear();
            reminders = storage.Get(ReminderItemStatus.Failed);
            Assert.AreEqual(0, reminders.Count);
            Assert.IsNotNull(reminders);
        }

        [TestMethod]
        public void MethodUpdate_Works_correctly()
        {
            var storage = new SqlServerReminderStorage(_connectionString);

            storage.Update(Guid.Parse("00000000-0000-0000-0000-222222222222"),
                            ReminderItemStatus.Ready);

            ReminderItem reminderItem = storage.
                Get(Guid.Parse("00000000-0000-0000-0000-222222222222"));

            Assert.AreEqual(ReminderItemStatus.Ready, reminderItem.Status);

        }
    }
}
