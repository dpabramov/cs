using System;

namespace MedService.Core
{
    public class DoctorAddedEventArgs : ModelDoctorImport
    {
        public Guid Id { get; set; }
    }
}