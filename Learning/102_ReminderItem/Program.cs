using System;
using System.Collections.Generic;

namespace _102_ReminderItem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ReminderItem> array = new List<ReminderItem>
            {
                new ReminderItem(DateTimeOffset.Parse("2022-04-02 17:55"),
                                     "Пора вставать!"),

                new PhoneReminderItem(DateTimeOffset.Parse("2022-04-02 17:55"),
                                     "Пора вставать!",
                                     "89888888888"),

                new ChatReminderItem(DateTimeOffset.Parse("2022-04-02 17:55"),
                                    "Пора вставать!",
                                    "Чат родных",
                                    "Дима_account")
            };

            foreach (ReminderItem ar in array)
            {
                ar.WriteProperties();
            }

            Console.ReadKey();
        }
    }
}
