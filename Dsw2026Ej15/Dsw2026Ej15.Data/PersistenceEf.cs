using Dsw2026Ej15.Data.Interfaces;
using Dsw2026Ej15.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Data
{
    public class PersistenceEf : IPersistence
    {
        private readonly Dsw2026Ej15DbContext _context;
        public PersistenceEf(Dsw2026Ej15DbContext context)
        {
             _context = context;
        }

        public async Task AddDoctor(Doctor doctor)
        {
            _context.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Doctor>> GetActiveDoctors()
        {
            return _context.Doctors.Where(d => d.IsActive);
        }

        public Task<Doctor?> GetDoctorById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Speciality?> GetSpecialityById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task InitializeData()
        {
            throw new NotImplementedException();
        }

        public Task UpdateDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
