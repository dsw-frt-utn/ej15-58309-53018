using System;
using System.Collections.Generic;
using System.Text;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Data.Dtos;

namespace Dsw2026Ej15.Data.Interfaces
{
    public interface IPersistence
    {
        List<Doctor> GetDoctors();
        List<Doctor> GetActiveDoctors();
        Doctor? GetDoctorById(Guid id);
        Speciality? GetSpecialityById(Guid id);
        List<Speciality> GetSpecialities();
        void AddDoctor(Doctor doctor);
        void RemoveDoctor(Doctor doctor);
        void InitializeData();
    }
}
