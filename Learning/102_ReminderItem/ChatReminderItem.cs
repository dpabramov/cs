using System;
using System.Collections.Generic;
using System.Text;

namespace _102_ReminderItem
{
    class ChatReminderItem : ReminderItem
    {
        //название чата
        public string ChatName { get; set; }
        //Имя аккаутна в чате
        public string AccountName { get; set; }

        public ChatReminderItem(DateTimeOffset alarmDate, string alarmMessage,
            string chatName, string accountName) :
            base(alarmDate, alarmMessage)
        {
            ChatName = chatName;
            AccountName = accountName;
        }

        public override void WriteProperties()
        {
            base.WriteProperties();
            Console.WriteLine($"ChatName: {ChatName}" +
                $"\nAccountName: {AccountName}");
        }

    }
}
