using Dsw2026Ej15.Data.Dtos;
using Dsw2026Ej15.Data.Interfaces;
using Dsw2026Ej15.Domain;
using System.Net.WebSockets;
using System.Reflection.Metadata;
using System.Text.Json;

namespace Dsw2026Ej15.Data
{
    public class PersistenceInMemory : IPersistence
    {
        private readonly List<Doctor> _doctors;
        private readonly List<Speciality> _specialities;
        public PersistenceInMemory()
        {
            InitializeData();
        }

        public void AddDoctor(Doctor doctor)
        {
            _doctors.Add(doctor);
        }
        public void RemoveDoctor(Doctor doctor)
        {
            _doctors?.Remove(doctor);
        }
        public List<Doctor> GetDoctors() => _doctors;

        public List<Speciality> GetSpecialities() => _specialities;
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
                    _specialities.Add(new Speciality { Name = data.Nombre, Description = data.Description });
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
                    _doctors.Add(new Doctor 
                    { Id = data.Id, 
                        Name = data.Name, 
                        IsActive = data.IsActive, 
                        Speciality = speciality});
                }
            }
        }
        public void InitializeData() 
        {
            InitializeSpecialities();
            InitializeDoctors();    
        }
        
    }
}
