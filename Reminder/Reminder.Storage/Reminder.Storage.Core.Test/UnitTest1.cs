using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Reminder.Storage.Core.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Constructor_Fillin_FieldsOfObject_Correctly()
        {
            //prepare
            DateTimeOffset date = DateTimeOffset.Parse("2022-04-22 12:31:04");
            const string message = "Закапать капли";
            const string contactId = "ADS456N";

            //do test
            ReminderItem reminderItem = new ReminderItem(date,
                message,
                contactId);

            //check
            Assert.IsNotNull(reminderItem);
            Assert.IsNotNull(reminderItem.Id);
            Assert.AreEqual(date, reminderItem.Date);
            Assert.AreEqual(message, reminderItem.Message);
            Assert.AreEqual(contactId, reminderItem.ContactId);
            Assert.AreEqual(ReminderItemStatus.Awaiting, reminderItem.Status);
        }
    }
}
