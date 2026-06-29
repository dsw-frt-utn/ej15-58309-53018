using System;
using System.Collections.Generic;
using System.Text;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Data.Dtos;

namespace Dsw2026Ej15.Data.Interfaces
{
    public interface IPersistence
    {
        Task<List<Doctor>?> GetActiveDoctors();
        Task<Doctor?> GetDoctorById(Guid id);
        Task<Speciality?> GetSpecialityById(Guid id);
        Task AddDoctor(Doctor doctor);
        //Task InitializeData();
        Task RemoveDoctor(Doctor doctor);
    }
}
