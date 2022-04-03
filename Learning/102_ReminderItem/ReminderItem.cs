using System;
using System.Collections.Generic;
using System.Text;

namespace _102_ReminderItem
{
    public class ReminderItem
    {
        public DateTimeOffset AlarmDate { get; set; } //время будильника

        public string AlarmMessage { get; set; } //сообщение на будильник

        public TimeSpan TimeToAlarm //время до срабатывания
        {
            get
            {
                TimeSpan interval = AlarmDate - DateTimeOffset.Now;
                return interval;
            }
        }

        public bool isOutDate //пора звонить
        {
            get
            {
                return (TimeToAlarm.Seconds < 0);
            }
        }

        public ReminderItem(DateTimeOffset alarmDate, string alarmMessage)
        {
            AlarmDate = alarmDate;
            AlarmMessage = alarmMessage;
        }

        public void WriteProperties()
        {
            Console.WriteLine($"AlarmDate: {AlarmDate}," +
                $"\nAlarmMessage: {AlarmMessage}" +
                $"\nTimeToAlarm: {TimeToAlarm}" +
                $"\nisOutDate: {isOutDate}");
        }
    }
}
