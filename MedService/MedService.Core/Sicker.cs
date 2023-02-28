using System;

namespace MedService.Core
{
    public class Sicker : Person
    {
        public Sicker(IMedServiceBot botClient,
                        Guid id,
                        string name,
                        string homeAddress,
                        string telephone,
                        string description,
                        string contactId,
                        string token) 
            : base( botClient,
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
