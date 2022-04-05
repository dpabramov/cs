using System;
using System.Collections.Generic;
using System.Text;

namespace _102_ReminderItem
{
    public class PhoneReminderItem : ReminderItem
    {
        //телефон для отпраки сообщений
        public string PhoneNumber { get; set; }

        public PhoneReminderItem(DateTimeOffset alarmDate, string alarmMessage, string phoneNumber)
            : base(alarmDate, alarmMessage)
        {
            PhoneNumber = phoneNumber;
        }

        public override void WriteProperties()
        {
            base.WriteProperties();
            Console.WriteLine($"PhoneNumber: {PhoneNumber}");
        }
    }
}
