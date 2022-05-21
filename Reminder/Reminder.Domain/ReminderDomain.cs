using System;
using System.Collections.Generic;
using System.Threading;
using Reminder.Storage.Core;
using Reminder.Domain.Models;
using Reminder.Receiver.Core;
using Reminder.Parsing;
using Reminder.Sender.Core;

namespace Reminder.Domain
{
    //наследуемся от IDisposable из-за того, 
    //что Timer реализует этот интерфейс
    public class ReminderDomain : IDisposable
    {
        private IReminderStorage _storage;

        private IReminderReceiver _receiver;

        private IReminderSender _sender;

        private TimeSpan _periodChangeStatusAwatingToReady;

        private TimeSpan _periodSendMessage;

        private Timer _timerChangeStatusAwatingToReady;

        private Timer _timerSendMessage;

        public Action<ReminderItem> SendReminder;

        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public event EventHandler<StatusChangedToReadyEventArgs> StatusChangedToReady;

        public event EventHandler<SendingSucceededEventArgs> SendingSucceeded;

        public event EventHandler<SendingFailedEventArgs> SendingFailed;

        public event EventHandler<MessageParsedSuccededEventArgs> MessageParsedSucceded;

        public event EventHandler<MessageParsedFaultEventArgs> MessageParsedFault;

        public event EventHandler<AddedStorageSuccededEventArgs> AddToStorageSucceded;

        public event EventHandler<AddedStorageFaultEventArgs> AddToStorageFault;

        public ReminderDomain(IReminderStorage Storage,
                            TimeSpan PeriodChangeStatusAwatingToReady,
                            TimeSpan PeriodSentMessage,
                            IReminderReceiver Receiver,
                            IReminderSender Sender)
        {
            _storage = Storage;
            _periodChangeStatusAwatingToReady = PeriodChangeStatusAwatingToReady;
            _periodSendMessage = PeriodSentMessage;
            _receiver = Receiver;
            _sender = Sender;

            _receiver.MessageReceived += (s, e) =>
            {
                ParsedMessage p;
                MessageReceived?.Invoke(this, 
                    new MessageReceivedEventArgs
                    {
                        ContactId = e.ContactId,
                        Message = e.Message
                    });

                try
                {
                    p = MessageParser.Parse(e.Message);

                    //event сообщение распарсено
                    MessageParsedSucceded?.Invoke(this,
                              new MessageParsedSuccededEventArgs
                              {
                                  Message = p
                              });
                }
                catch (Exception exception)
                {
                    //event сообщение не распарсено
                    var mpf = new MessageParsedFaultEventArgs
                    {
                        MessageParseException = exception
                    };

                    MessageParsedFault?.Invoke(this, mpf);

                    //дальнейшая обработка сообщения не имее смысл, выходим
                    return;
                }

                ReminderItem reminderItem = new ReminderItem(p.Date,
                    p.Message,
                    e.ContactId);

                try
                {
                    _storage.Add(reminderItem);

                    //event добавлено в хранилище успешно
                    AddedStorageSuccededEventArgs ass = new AddedStorageSuccededEventArgs
                    {
                        ReminderItem = reminderItem
                    };
                    AddToStorageSucceded?.Invoke(this, ass);
                }
                catch (Exception ex)
                {
                    //event ошибка добавлено в хранилище
                    AddedStorageFaultEventArgs asf = new AddedStorageFaultEventArgs
                    {
                        exception = ex
                    };
                    AddToStorageFault?.Invoke(this, asf);
                }
            };

            SendReminder = (ri) =>
            {
                _sender.Send(ri.ContactId, ri.Message);
            };
        }

        public ReminderDomain(IReminderStorage Storage,
                             IReminderReceiver Receiver,
                             IReminderSender Sender)
                      : this(Storage,
                            TimeSpan.FromSeconds(1),
                            TimeSpan.FromSeconds(1),
                            Receiver,
                            Sender)
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

            _receiver.Run();
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
