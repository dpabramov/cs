using MedService.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MedService.Domain
{
    public class MedServiceDomain : IDisposable
    {
        private IMedServiceStorage _storage;

        private TimeSpan _awaitingScheduleTimeSpan { get; set; }

        private TimeSpan _awaitingDistributeTimeSpan { get; set; }

        private Timer _scheduleTimer;

        private Timer _distributeTimer;

        public event EventHandler<ToScheduleEventArgs> OrderScheduled;

        public event EventHandler<ToDistributeEventArgs> OrderDistributed;

        public MedServiceDomain(IMedServiceStorage storage,
                                TimeSpan awaitingScheduleTimeSpan,
                                TimeSpan awaitingDistributeTimeSpan)
        {
            _storage = storage;

            _awaitingScheduleTimeSpan = awaitingScheduleTimeSpan;

            _awaitingDistributeTimeSpan = awaitingDistributeTimeSpan;

            _storage.GetAllSickers().ForEach(s => s.BotClient.OrderCreated += BotClient_OrderCreated);
        }

        private void BotClient_OrderCreated(object sender, OrderCreatedEventArgs e)
        {
            _storage.CreateOrder(e.Date,
                     _storage.GetSickerByContactId(e.ContactId),
                     null,
                     e.Status,
                     e.ServiceItems,
                     e.Description);
        }

        public void Run()
        {
            _storage
                .GetAllDoctors()
                .ForEach(d =>
                    {
                        d.BotClient.StartReceiving();
                    });

            _storage
                .GetAllSickers()
                .ForEach(d =>
                    {
                        d.BotClient.StartReceiving();
                    });

            _scheduleTimer = new Timer(ToSheduleOrders,
                                        null,
                                        TimeSpan.FromSeconds(30),
                                        _awaitingScheduleTimeSpan);

            _distributeTimer = new Timer(ToDistributeOrders,
                                            null,
                                            TimeSpan.FromMinutes(1),
                                            _awaitingDistributeTimeSpan);
        }


        private void ToDistributeOrders(object state)
        {
            List<Order> scheduledOrders = _storage.GetOrdersByStatus(MedServiceStatus.Scheduled);

            foreach (var order in scheduledOrders)
            {
                if (order.Doctor != null)
                {
                    _storage.UpdateOrderStatus(order.Id, MedServiceStatus.Distributed);

                    OrderDistributed?.Invoke(this,
                                        new ToDistributeEventArgs()
                                        {
                                            OrderGuid = order.Id,
                                            status = MedServiceStatus.Distributed
                                        });

                    order.Doctor.BotClient.Send(order.Doctor.ContactId,
                             MedServiceMessages.GetMessageDistributedOrderInfoToDoctor(order));
                }
            }
        }

        private void ToSheduleOrders(object state)
        {
            List<Order> openedOrders = _storage.GetOrdersByStatus(MedServiceStatus.Opened);

            foreach (Order order in openedOrders)
            {
                Doctor randomDoctor = _storage.GetRandomDoctor();

                if (randomDoctor != null)
                {
                    _storage.UpdateOrderDoctor(order.Id, _storage.GetRandomDoctor());
                    _storage.UpdateOrderStatus(order.Id, MedServiceStatus.Scheduled);

                    OrderScheduled?.Invoke(this,
                                            new ToScheduleEventArgs()
                                            {
                                                OrderGuid = order.Id,
                                                doctor = order.Doctor,
                                                status = order.Status
                                            });

                    order.Doctor.BotClient.Send(order.Doctor.ContactId,
                            MedServiceMessages.GetMessageSchedulededOrderInfoToDoctor(order));
                }
            }
        }

        public void Stop()
        {
            //_storage.GetAllDoctors().ForEach(d => d.BotClient.StopReceiving());

            //_storage.GetAllSickers().ForEach(d => d.BotClient.StopReceiving());
        }

        public void Dispose()
        {
            _scheduleTimer?.Dispose();

            _distributeTimer?.Dispose();
        }
    }
}
