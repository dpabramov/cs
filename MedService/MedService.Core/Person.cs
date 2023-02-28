using System;
using System.Collections.Generic;
using System.Text;

namespace MedService.Core
{
    public class Person
    {
        public IMedServiceBot BotClient;

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string HomeAddress { get; set; }

        public string Telephone { get; set; }

        public string Description { get; set; }

        public string ContactId { get; set; }

        public string Token { get; set; }

        public Person(IMedServiceBot botClient,
                        Guid id,
                        string name,
                        string homeAddress,
                        string telephone,
                        string description,
                        string contactId,
                        string token)
        {
            BotClient = botClient;
            Id = id;
            Name = name;
            HomeAddress = homeAddress;
            Telephone = telephone;
            Description = description;
            ContactId = contactId;
            Token = token;
        }
    }
}
