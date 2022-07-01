using Reminder.Storage.Core;
using System;

namespace Reminder.Domain
{
    public class AddedStorageSuccededEventArgs : EventArgs
    {
        //public ReminderItem ReminderItem;

        public Guid Id { get; set; } //идентификатор объекта

        public DateTimeOffset Date { get; set; } //время будильника

        public string Message { get; set; } //сообщение на будильник

        public string ContactId { get; set; }  //автор сообщения

        public ReminderItemStatus Status { get; set; }

        public AddedStorageSuccededEventArgs()
        {
        }

        public AddedStorageSuccededEventArgs(ReminderItem reminderItem)
        {
            Id = reminderItem.Id;
            Date = reminderItem.Date;
            Message = reminderItem.Message;
            ContactId = reminderItem.ContactId;
            Status = reminderItem.Status;
        }
    }
}