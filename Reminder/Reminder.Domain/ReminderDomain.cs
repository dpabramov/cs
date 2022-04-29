using System;
using System.Collections.Generic;
using System.Threading;
using Reminder.Storage.Core;
using Reminder.Domain.Models;


namespace Reminder.Domain
{
    //наследуемся от IDisposable из-за того, 
    //что Timer реализует этот интерфейс
    public class ReminderDomain : IDisposable
    {
        private IReminderStorage _storage;

        private TimeSpan _periodChangeStatusAwatingToReady;

        private TimeSpan _periodSendMessage;

        private Timer _timerChangeStatusAwatingToReady;

        private Timer _timerSendMessage;

        public Action<ReminderItem> SendReminder;

        public event EventHandler<StatusChangedToReadyEventArgs> StatusChangedToReady;

        public event EventHandler<SendingSucceededEventArgs> SendingSucceeded;

        public event EventHandler<SendingFailedEventArgs> SendingFailed;

        public ReminderDomain(IReminderStorage Storage,
                            TimeSpan PeriodChangeStatusAwatingToReady,
                            TimeSpan PeriodSentMessage)
        {
            _storage = Storage;
            _periodChangeStatusAwatingToReady = PeriodChangeStatusAwatingToReady;
            _periodSendMessage = PeriodSentMessage;
        }

        public ReminderDomain(IReminderStorage Storage) : this(Storage,
                                               TimeSpan.FromSeconds(1),
                                               TimeSpan.FromSeconds(1))
        {
        }

        public void Run()
        {
            _timerChangeStatusAwatingToReady = new Timer(ChangeStatusToReady,
                                            null,
                                            TimeSpan.Zero,
                                            _periodChangeStatusAwatingToReady);

            _timerSendMessage = new Timer(SendReadyReminders,
                                        null,
                                        TimeSpan.FromSeconds(2),
                                        _periodSendMessage);
        }

        private void SendReadyReminders(object state)
        {
            //найти все сообщения в статусе ready
            //отправить их и в зависимости от результата 
            //проставить статус sent или fault

            List<ReminderItem> readyReminders = _storage.Get(ReminderItemStatus.Ready);

            foreach (var reminder in readyReminders)
            {
                //если в sendere отправить не получится, то там бросим Exception
                //если не получилось отправить статус - fault
                try
                {
                    //отправляем сообщение, Для этого в sender делаем метод отправки
                    //и там добавляем его в делегат  SendReminder
                    SendReminder?.Invoke(reminder);

                    //изменяем статус записи в хранилище на Sent
                    _storage.Update(reminder.Id, ReminderItemStatus.Sent);

                    //если досюда не свалились, зажигаем событие SendingSucceeded
                    SendingSucceededEventArgs sendingSucceededEventArgs = new SendingSucceededEventArgs
                    {
                        Item = reminder
                    };
                    SendingSucceeded?.Invoke(this, sendingSucceededEventArgs);
                }
                catch (Exception e)
                {
                    //если свалились в исключение, изменяем статус записи в хранилище на Failed
                    _storage.Update(reminder.Id, ReminderItemStatus.Failed);

                    // ... и зажигаем SendingFailed
                    SendingFailedEventArgs sendingFailedEventArgsEventArgs = new SendingFailedEventArgs
                    {
                        Item = reminder,
                        SendingException = e
                    };
                    SendingFailed?.Invoke(this, sendingFailedEventArgsEventArgs);
                }
            }
        }

        private void ChangeStatusToReady(object state)
        {
            List<ReminderItem> reminders = _storage.Get(ReminderItemStatus.Awaiting);

            foreach (var reminder in reminders)
            {
                if (reminder.isReadyToSent)
                    _storage.Update(reminder.Id, ReminderItemStatus.Ready);

                //зажигаем событие статус изменен на ready
                StatusChangedToReady?.Invoke(this,
                             new StatusChangedToReadyEventArgs
                             {
                                 Item = reminder
                             });
            }
        }

        public void Dispose()
        {
            // реализуем IDisposable
            _timerChangeStatusAwatingToReady?.Dispose();

            _timerSendMessage?.Dispose();
        }
    }
}
