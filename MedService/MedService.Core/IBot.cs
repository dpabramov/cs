using System;

namespace MedService.Core
{
    public interface IMedServiceBot
    {
        string Token { get; set; }

        event EventHandler<OrderCreatedEventArgs> OrderCreated;

        void StartReceiving();

        void Send(string contactId, string message);
    }
}
