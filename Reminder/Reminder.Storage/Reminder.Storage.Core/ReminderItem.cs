﻿using System;

namespace Reminder.Storage.Core
{
    public class ReminderItem
    {
        public Guid Id { get; set; } //идентификатор объекта

        public DateTimeOffset Date { get; set; } //время будильника

        public string Message { get; set; } //сообщение на будильник

        public string ContactId { get; set; }  //автор сообщения

        public ReminderItemStatus Status { get; set; }

        public bool isReadyToSent => Date < DateTimeOffset.Now;

        public TimeSpan TimeToAlarm => Date - DateTimeOffset.Now;

        public ReminderItem(Guid id, 
                            DateTimeOffset date, 
                            string message, 
                            string contactId, 
                            ReminderItemStatus status)
        {
            Id = id;
            Date = date;
            Message = message;
            ContactId = contactId;
            Status = status;
        }

        public ReminderItem()
        {
        }
    }
}

