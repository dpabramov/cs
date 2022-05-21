using System;

namespace Reminder.Domain
{
    public class AddedStorageFaultEventArgs: EventArgs
    {
        public Exception exception;
    }
}