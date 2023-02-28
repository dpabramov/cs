using System;
using System.Collections.Generic;
using System.Text;

namespace MedService.Core
{
    public interface IMedServiceStorage
    {
        //event EventHandler<DoctorAddedEventArgs> DoctorAdded;

        // работа с больным
        Sicker AddSicker(IMedServiceBot botClient,
                        string name,
                        string homeAddress,
                        string telephone,
                        string description,
                        string contactId,
                        string token);

        void UpdateSicker(Guid id, Sicker newSicker);

        void DeleteSicker(Guid id);

        Sicker GetSicker(Guid id);

        Sicker GetSickerByContactId(string contactId);

        //работа с докторами
        Doctor AddDoctor(IMedServiceBot botClient,
                        string name,
                        string homeAddress,
                        string telephone,
                        string description,
                        string contactId,
                        string token);

        void UpdateDoctor(Guid id, Doctor newDoctor);

        void DeleteDoctor(Guid id);

        Doctor GetDoctor(Guid id);

        Doctor GetRandomDoctor();

        List<Doctor> GetAllDoctors();


        //работа со справочником медицинских услуг
        ServiceItem AddServiceItem(string name, decimal price, string description);

        void UpdateServiceItem(Guid id, ServiceItem serviceItem);

        void DeleteServiceItem(Guid id);

        ServiceItem GetServiceItem(Guid id);

        // работа с заявками на оказание медицинских услуг
        Guid CreateOrder(DateTimeOffset dateTimeOffset,
                            Sicker sicker,
                            Doctor doctor,
                            MedServiceStatus status,
                            List<ServiceItem> items,
                            string description);

        void RemoveOrder(Guid id);

        void UpdateOrderStatus(Guid id, MedServiceStatus status);

        void UpdateOrderDoctor(Guid id, Doctor doctor);

        List<Order> GetOrdersByStatus(MedServiceStatus status);

        List<Sicker> GetAllSickers();
    }
}
