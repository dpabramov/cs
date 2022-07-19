using System;
using System.ComponentModel.DataAnnotations;
using Reminder.Storage.Core;

namespace Reminder.Storage.WebApi.Core
{
    public class ReminderItemGetModel
    {
        [Required]
        public Guid Id { get; set; } //идентификатор объекта

        [Required]
        public DateTimeOffset Date { get; set; } //время будильника

        [Required]
        public string Message { get; set; } //сообщение на будильник

        [Required]
        public string ContactId { get; set; }  //автор сообщения

        [Required]
        public ReminderItemStatus Status { get; set; }

        public ReminderItemGetModel()
        {
        }

        public ReminderItemGetModel(ReminderItem reminderItem)
        {
            Id = reminderItem.Id;
            Date = reminderItem.Date;
            Message = reminderItem.Message;
            ContactId = reminderItem.ContactId;
            Status = reminderItem.Status;
        }

    }
}
