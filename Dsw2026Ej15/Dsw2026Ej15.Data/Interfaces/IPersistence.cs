using System;
using System.Collections.Generic;
using System.Text;
using Dsw2026Ej15.Domain;

namespace Dsw2026Ej15.Data.Interfaces
{
    public interface IPersistence
    {
        List<Doctor> GetDoctors();
        List<Speciality> GetSpecialities();
        void AddDoctor(Doctor doctor);
        void RemoveDoctor(Doctor doctor);
        void InitializeData();
    }
}
