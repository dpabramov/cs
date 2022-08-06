using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Domain.Models;
using Reminder.Receiver.Core;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using Moq;
using Reminder.Sender.Core;

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
            ReminderItem reminderItem = new ReminderItem(Guid.NewGuid(),
                                                DateTimeOffset.Now, 
                                                null, 
                                                null, 
                                                ReminderItemStatus.Awaiting);

            InMemoryReminderStorage inMemoryReminderStorage = new InMemoryReminderStorage();
            inMemoryReminderStorage.Add(reminderItem);

            //������� ��������� receiver � sender � ������� mock
            var moqReceiver = new Mock<IReminderReceiver>();
            var fakeReceiver = moqReceiver.Object;

            var moqSender = new Mock<IReminderSender>();
            var fakeSender = moqSender.Object;

            //�.�. ����� ReminderDomain ��������� �� IDisposable
            using (ReminderDomain reminderDomain = new ReminderDomain(inMemoryReminderStorage,
                                                                       fakeReceiver,
                                                                       fakeSender))
            {
                //������������� �� �������, ����� ������ � ���� ������
                reminderDomain.StatusChangedToReady +=
                    (Object sender, StatusChangedToReadyEventArgs args) => isReadyStatus = true;

                reminderDomain.Run();
                //����� ������ ����� ���������� ������ �� ������� �������
                //� �� ���������� �� ������� �������
                System.Threading.Thread.Sleep(5000);
            }

            //���������
            Assert.AreEqual(true, isReadyStatus);
        }

        [TestMethod]
        public void Method_Run_Send_Message_And__Update_Status_To_Sent()
        {
            var mockReceiver = new Mock<IReminderReceiver>();
            var fakeReceiver = mockReceiver.Object;

            var mockSender = new Mock<IReminderSender>();
            var fakeSender = mockSender.Object;

            ReminderItem reminderItem = new ReminderItem(Guid.NewGuid(), 
                                                    DateTimeOffset.Now, 
                                                    null, 
                                                    null,
                                                    ReminderItemStatus.Awaiting);
            InMemoryReminderStorage inMemoryReminderStorage = new InMemoryReminderStorage();
            inMemoryReminderStorage.Add(reminderItem);

            //�.�. ����� ReminderDomain ��������� �� IDisposable
            using (ReminderDomain reminderDomain = new ReminderDomain(inMemoryReminderStorage,
                                                                    fakeReceiver,
                                                                    fakeSender))
            {
                //reminderDomain.SendReminder += OnSendReminder;
                reminderDomain.SendingSucceeded += (Object sender, SendingSucceededEventArgs e) 
                                => isSentStatus = true;
                    
                reminderDomain.Run();
                //����� ������ ����� ���������� ������ �� ������� �������
                //� �� ���������� �� ������� �������
                System.Threading.Thread.Sleep(5000);
            }

            Assert.AreEqual(true, isSentStatus);
            Assert.AreEqual(ReminderItemStatus.Sent, reminderItem.Status);

        }

        //private void OnSendReminder(ReminderItem obj)
        //{
        //}

        //[TestMethod]
        //public void Method_Run_Send_Message_And__Update_Status_To_Faulure()
        //{
        //    var mockReceiver = new Mock<IReminderReceiver>();
        //    var fakeReceiver = mockReceiver.Object;

        //    var mockSender = new Mock<IReminderSender>();
        //    var fakeSender = mockSender.Object;

        //    ReminderItem reminderItem = new ReminderItem(Guid.NewGuid(),
        //                                                DateTimeOffset.Now, 
        //                                                null, 
        //                                                null,
        //                                                ReminderItemStatus.Awaiting);
        //    InMemoryReminderStorage inMemoryReminderStorage = new InMemoryReminderStorage();
        //    inMemoryReminderStorage.Add(reminderItem);

        //    //�.�. ����� ReminderDomain ��������� �� IDisposable
        //    using (ReminderDomain reminderDomain = new ReminderDomain(inMemoryReminderStorage, 
        //                                                              fakeReceiver, 
        //                                                              fakeSender))
        //    {
        //        //reminderDomain.SendReminder += OnSendReminderFailed;
        //        reminderDomain.SendingFailed += (Object sender, SendingFailedEventArgs e) => isFaultStatus = true;

        //        reminderDomain.Run();
        //        //����� ������ ����� ���������� ������ �� ������� �������
        //        //� �� ���������� �� ������� �������
        //        System.Threading.Thread.Sleep(5000);
        //    }

        //    Assert.AreEqual(true, isFaultStatus);
        //    Assert.AreEqual(ReminderItemStatus.Failed, reminderItem.Status);
        //}

        private void OnSendReminderFailed(ReminderItem obj)
        {
            throw new Exception();
        }
    }
}
