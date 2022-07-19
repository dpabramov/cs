using Reminder.Storage.Core;

namespace Reminder.Domain.Models
{
    public class StatusChangedToReadyEventArgs
    {
        public ReminderItem Item { get; set; }
    }
}