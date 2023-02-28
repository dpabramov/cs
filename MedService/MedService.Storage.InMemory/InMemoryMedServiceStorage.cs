using System;
using System.Linq;
using System.Collections.Generic;
using MedService.Core;


namespace MedService.Storage.InMemory
{
    public class InMemoryMedServiceStorage : IMedServiceStorage
    {
        internal Dictionary<Guid, Sicker> _sickers;

        internal Dictionary<Guid, Doctor> _doctors;

        internal Dictionary<Guid, ServiceItem> _serviceItems;

        internal Dictionary<Guid, Order> _orders;

        public object Id { get; private set; }

        public InMemoryMedServiceStorage()
        {
            _sickers = new Dictionary<Guid, Sicker>();

            _doctors = new Dictionary<Guid, Doctor>();

            _serviceItems = new Dictionary<Guid, ServiceItem>();

            _orders = new Dictionary<Guid, Order>();
        }

        public Doctor AddDoctor(IMedServiceBot botClient,
                        string name,
                        string homeAddress,
                        string telephone,
                        string description,
                        string contactId,
                        string token)
        {
            Doctor doctor = new Doctor(botClient,
                        Guid.NewGuid(),
                        name,
                        homeAddress,
                        telephone,
                        description,
                        contactId,
                        token);

            _doctors.Add(doctor.Id, doctor);

            return doctor;
        }

        public ServiceItem AddServiceItem(string name, decimal price, string description)
        {
            ServiceItem serviceItem = new ServiceItem()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = price,
                Description = description
            };

            _serviceItems.Add(serviceItem.Id, serviceItem);

            return serviceItem;
        }

        public Sicker AddSicker(IMedServiceBot botClient,
                        string name,
                        string homeAddress,
                        string telephone,
                        string description,
                        string contactId,
                        string token)
        {
            Sicker sicker = new Sicker(botClient,
                                Guid.NewGuid(),
                                name,
                                homeAddress,
                                telephone,
                                description,
                                contactId,
                                token);

            _sickers.Add(sicker.Id, sicker);

            return sicker;
        }

        public Guid CreateOrder(DateTimeOffset dateTimeOffset,
                                Sicker sicker,
                                Doctor doctor,
                                MedServiceStatus status,
                                List<ServiceItem> items,
                                string description)
        {
            Order order = new Order()
            {
                Id = Guid.NewGuid(),
                Date = dateTimeOffset,
                Sicker = sicker,
                Doctor = doctor,
                Status = status,
                ServiceItems = items,
                Description = description
            };

            _orders.Add(order.Id, order);

            return order.Id;
        }

        public void DeleteDoctor(Guid id)
        {
            if (_doctors.ContainsKey(id))
                _doctors.Remove(id);
        }

        public void DeleteServiceItem(Guid id)
        {
            if (_serviceItems.ContainsKey(id))
                _serviceItems.Remove(id);

        }

        public void DeleteSicker(Guid id)
        {
            if (_sickers.ContainsKey(id))
            {
                _sickers.Remove(id);
            }
        }

        public List<Doctor> GetAllDoctors()
        {
            return _doctors.Values.ToList();
        }

        public Doctor GetDoctor(Guid id)
        {
            return _doctors.ContainsKey(id)
                  ? _doctors[id]
                  : null;
        }

        public List<Order> GetOrdersByStatus(MedServiceStatus status)
        {
            return _orders
                    .Values
                    .Where(o => o.Status == status)
                    .ToList();
        }

        public Doctor GetRandomDoctor()
        {
            int doctorsCount = _doctors.Count;
            Random random = new Random();

            if (doctorsCount == 0)
                return null;

            int RandKey = random.Next(0, doctorsCount);

            List<Doctor> doctors = _doctors.Values.ToList();

            return doctors[RandKey];
        }

        public ServiceItem GetServiceItem(Guid id)
        {
            return _serviceItems.ContainsKey(id)
                    ? _serviceItems[id]
                    : null;
        }

        public Sicker GetSicker(Guid id)
        {
            return _sickers.ContainsKey(id)
                    ? _sickers[id]
                    : null;
        }

        public void RemoveOrder(Guid id)
        {
            if (_orders.ContainsKey(id))
                _orders.Remove(id);
        }

        public void UpdateDoctor(Guid id, Doctor newDoctor)
        {
            if (_doctors.ContainsKey(id))
            {
                _doctors[id].Name = newDoctor.Name;
                _doctors[id].HomeAddress = newDoctor.HomeAddress;
                _doctors[id].Telephone = newDoctor.Telephone;
                _doctors[id].Description = newDoctor.Description;
            }
        }

        public void UpdateOrderDoctor(Guid id, Doctor doctor)
        {
            if (_orders.ContainsKey(id))
                _orders[id].Doctor = doctor;
        }

        public void UpdateOrderStatus(Guid id, MedServiceStatus status)
        {
            if (_orders.ContainsKey(id))
                _orders[id].Status = status;
        }

        public void UpdateServiceItem(Guid id, ServiceItem serviceItem)
        {
            if (_serviceItems.ContainsKey(id))
            {
                _serviceItems[id].Name = serviceItem.Name;
                _serviceItems[id].Price = serviceItem.Price;
                _serviceItems[id].Description = serviceItem.Description;
            }
        }

        public void UpdateSicker(Guid id, Sicker newSicker)
        {
            if (_sickers.ContainsKey(id))
            {
                _sickers[id].Name = newSicker.Name;
                _sickers[id].HomeAddress = newSicker.HomeAddress;
                _sickers[id].Telephone = newSicker.Telephone;
            }
        }

        public List<Sicker> GetAllSickers()
        {
            return _sickers.Values.ToList();
        }

        public Sicker GetSickerByContactId(string contactId)
        {
            return _sickers.FirstOrDefault(s => s.Value.ContactId == contactId).Value;
        }
    }
}
