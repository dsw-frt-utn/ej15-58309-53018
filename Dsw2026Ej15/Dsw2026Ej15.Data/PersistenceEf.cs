using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Dsw2026Ej15.Data.Interfaces;
using Dsw2026Ej15.Domain.Entities;

public class PersistenceEf : IPersistence
{
    public List<Doctor> GetActiveDoctors()
    {
        using var context = new ApplicationDbContext();
        return context.Doctors.Include(d => d.Speciality).ToList();
    }

    public Doctor? GetDoctorById(Guid id)
    {
        using var context = new ApplicationDbContext();
        return context.Doctors.Include(d => d.Speciality).FirstOrDefault(d => d.Id == id);
    }

    public Speciality? GetSpecialityById(Guid id)
    {
        using var context = new ApplicationDbContext();
        return context.Specialities.FirstOrDefault(s => s.Id == id);
    }

    public void AddDoctor(Doctor doctor)
    {
        using var context = new ApplicationDbContext();
        context.Doctors.Add(doctor);
        context.SaveChanges();
    }

    public void RemoveDoctor(Doctor doctor)
    {
        using var context = new ApplicationDbContext();
        context.Doctors.Remove(doctor);
        context.SaveChanges();
    }

    public void InitializeData()
    {
        using var context = new ApplicationDbContext();
        // me asegura que la base de datos esté creada al iniciar
        context.Database.EnsureCreated();
    }
}