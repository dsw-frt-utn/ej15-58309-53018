using Dsw2026Ej15.Data.Dtos;
using Dsw2026Ej15.Data.Interfaces;
using Dsw2026Ej15.Domain.Entities;
using System.Net.WebSockets;
using System.Reflection.Metadata;
using System.Text.Json;

namespace Dsw2026Ej15.Data
{
    public class PersistenceInMemory : IPersistence
    {
        private readonly List<Doctor> _doctors = [];
        private readonly List<Speciality> _specialities = [];
        public PersistenceInMemory()
        {
            InitializeData();
        }

        public void AddDoctor(Doctor doctor) => _doctors.Add(doctor);   
        public Doctor? GetDoctorById(Guid id) => _doctors.Find(d => d.Id == id);
        public List<Doctor> GetActiveDoctors() => (from d in _doctors where d.IsActive select d).ToList();
        public Speciality? GetSpecialityById(Guid id) => _specialities.Find(s => s.Id == id);
        public void UpdateDoctor(Doctor doctor)
        {
            _doctors.Remove(doctor);
            _doctors.Add(doctor);
        }


        #region not used
        
        private List<Doctor> GetDoctors() => _doctors;
        private List<Speciality> GetSpecialities() => _specialities;
        #endregion

        #region private methods
        private List<T>? LoadData<T>(string fileName) //TODO: Implementación asíncrona
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sources", $"{fileName}.json");
            string jsonContent = File.ReadAllText(jsonPath);
            return JsonSerializer.Deserialize<List<T>>(jsonContent);
        }
        private void InitializeSpecialities() 
        {
            var specialityData = LoadData<SpecialityDto>("specialities");
            if (specialityData != null)
            {
                foreach (var data in specialityData)
                {
                    _specialities.Add(new Speciality {Id = data.Id, Name = data.Nombre, Description = data.Description });
                }
            }
        }
        private void InitializeDoctors() 
        {
            var doctorsData = LoadData<DoctorDto>("doctors");
            if (doctorsData != null)
            {
                foreach (var data in doctorsData)
                {
                    var speciality = _specialities.Find(s => s.Id == data.SpecialityId);
                    if(speciality != null)
                    _doctors.Add(new Doctor  (data.Id, data.Name, data.LicenseNumber, data.IsActive, speciality));
                }
            }
        }
        public void InitializeData() 
        {
            InitializeSpecialities();
            InitializeDoctors();    
        }
        #endregion
    }
}
