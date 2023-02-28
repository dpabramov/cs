using System;
using System.Collections.Generic;
using System.Text;

namespace MedService.Core
{
    public class Doctor : Person
    {
        public Doctor(IMedServiceBot botClient,
                        Guid id,
                        string name,
                        string homeAddress,
                        string telephone,
                        string description,
                        string contactId,
                        string token) 
            : base(botClient,
                     id,
                     name,
                     homeAddress,
                     telephone,
                     description,
                     contactId,
                     token)
        {
        }
    }
}
