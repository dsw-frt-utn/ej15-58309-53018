using Dsw2026Ej15.Data.Dtos;
using Dsw2026Ej15.Data.Interfaces;
using Dsw2026Ej15.Data.Utils;
using Dsw2026Ej15.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Dsw2026Ej15.Data
{
    public class PersistenceEf : IPersistence
    {
        private readonly Dsw2026Ej15DbContext _context;
        public PersistenceEf(Dsw2026Ej15DbContext context)
        {
             _context = context;
             InitializeData();
        }
        public void InitializeData()
        {
            _context.Seedwork<Speciality>("specialities");
            _context.Seedwork<Doctor>("doctors");
        }


        public async Task AddDoctor(Doctor doctor)
        {
            _context.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Doctor>?> GetActiveDoctors()
        {
            return await _context.Doctors.
                Include(d => d.Speciality).
                Where(d => d.IsActive).
                ToListAsync();
        }

        public async Task<Doctor?> GetDoctorById(Guid id)
        {
            return await _context.Doctors.
                Include(d => d.Speciality).
                SingleOrDefaultAsync(d => d.Id == id && d.IsActive);
        }

        public async Task<Speciality?> GetSpecialityById(Guid id)
        {
           return await _context.
                Set<Speciality>().
                SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task RemoveDoctor(Doctor doctor)
        {
            doctor.Deactivate();
            await _context.SaveChangesAsync();
            
        }

        #region private methods
        //private List<T>? LoadData<T>(string fileName) //TODO: Implementación asíncrona
        //{
        //    string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sources", $"{fileName}.json");
        //    string jsonContent = File.ReadAllText(jsonPath);
        //    return JsonSerializer.Deserialize<List<T>>(jsonContent);
        //}
        //private async Task InitializeSpecialities()
        //{
        //    var specialityData = LoadData<SpecialityDto>("specialities");
        //    if (specialityData != null)
        //    {
        //        foreach (var data in specialityData)
        //        {
        //            _context.Specialities.Add(new Speciality(data.Id, data.Nombre, data.Description));
        //        }
        //        //await _context.SaveChangesAsync();
        //        _context.SaveChanges();
        //    }
        //}
        //private async Task InitializeDoctors()
        //{
        //    var doctorsData = LoadData<DoctorDto>("doctors");
        //    if (doctorsData != null)
        //    {
        //        foreach (var data in doctorsData)
        //        {
        //            var speciality = _context.Specialities.Find(data.SpecialityId);
        //            if (speciality != null)
        //                _context.Doctors.Add(new Doctor(data.Id, data.Name, data.LicenseNumber, data.IsActive, speciality));
        //        }
        //        await _context.SaveChangesAsync();
        //    }
        //}
        #endregion
    }
}
