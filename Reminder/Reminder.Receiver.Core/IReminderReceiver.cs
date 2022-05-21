using System;
using Reminder.Receiver.Core.Models;

namespace Reminder.Receiver.Core
{
    public interface IReminderReceiver
    {
        event EventHandler<MessageReceivedEventArgs> MessageReceived;

        void Run();
    }
}
