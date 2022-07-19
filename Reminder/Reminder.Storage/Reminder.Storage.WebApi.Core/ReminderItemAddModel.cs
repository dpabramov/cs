using System;
using System.ComponentModel.DataAnnotations;
using Reminder.Storage.Core;

namespace Reminder.Storage.WebApi.Core
{
    public class ReminderItemAddModel
    {
        [Required]
        public DateTimeOffset Date { get; set; } //время будильника

        [Required]
        public string Message { get; set; } //сообщение на будильник

        [Required]
        public string ContactId { get; set; }  //автор сообщения

        public ReminderItemAddModel() {}

        public ReminderItemAddModel(DateTimeOffset date,
                                    string message,
                                    string contactId)
        {
            Date = date;
            Message = message;
            ContactId = contactId;
        }

        public ReminderItem ConvertToReminderItem()
        {
            return new ReminderItem(Guid.NewGuid(), 
                                    Date, 
                                    Message, 
                                    ContactId, 
                                    ReminderItemStatus.Awaiting);
        }

    }
}
