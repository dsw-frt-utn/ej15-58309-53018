using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dsw2026Ej15.Domain.Entities
{
    public class Doctor : BaseEntity
    {
        public string Name { get; init; }
        public string LicenseNumber { get; init; }
        public bool IsActive { get; private set; } = true;
        public Guid? SpecialityId { get; set; }
        public Speciality? Speciality { get; private set; }

        public Doctor()
        {
            
        }
        public Doctor(string name, string licenseNumber, Speciality speciality)
        {
            Name = name;   
            LicenseNumber = licenseNumber;    
            Speciality = speciality;
            IsActive = true;
        }

        public Doctor(Guid id, string name, string licenseNumber, bool isActive, Speciality speciality) : base(id)
        {
            Name = name;
            LicenseNumber = licenseNumber;
            Speciality = speciality;
            IsActive = isActive;
        }

        public void Deactivate() => IsActive = false;
    }
}
