using Reminder.Storage.Core;
using System;

namespace Reminder.Domain
{
    public class AddedStorageFaultEventArgs : EventArgs
    {
        public Guid Id { get; set; } //идентификатор объекта

        public DateTimeOffset Date { get; set; } //время будильника

        public string Message { get; set; } //сообщение на будильник

        public string ContactId { get; set; }  //автор сообщения

        public ReminderItemStatus Status { get; set; }

        public Exception Except;

        public AddedStorageFaultEventArgs()
        {
        }

        public AddedStorageFaultEventArgs(ReminderItem reminderItem, Exception exception)
        {
            Id = reminderItem.Id;
            Date = reminderItem.Date;
            Message = reminderItem.Message;
            ContactId = reminderItem.ContactId;
            Status = reminderItem.Status;
            Except = exception;
        }
    }
}