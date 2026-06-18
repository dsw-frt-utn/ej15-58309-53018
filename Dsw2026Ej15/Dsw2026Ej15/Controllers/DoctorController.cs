using Microsoft.AspNetCore.Mvc;
using Dsw2026Ej15.Data.Interfaces;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Api.Models;

namespace Dsw2026Ej15.Api.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorController : ControllerBase
    {
        private readonly IPersistence _doctorsData;

        public DoctorController(IPersistence doctorsData)
        {
            _doctorsData = doctorsData;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DoctorModel.Request request)
        {
            //validaciones acá por ahora. Más adelante, las validaciones estarán en una capa de aplicación (al menos aquellas que estén referidas al negocio)
            _doctorsData.AddDoctor(request);
            // return CreatedAtAction(nameof(Get), new { id = doctor.Id }, doctor);
        }

            var nuevoDoctor = new Doctor
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                LicenseNumber = request.LicenseNumber,
                IsActive = true,
                Speciality = speciality
            };

            _doctorsData.AddDoctor(nuevoDoctor);

            return Created("", null);
        }

        [HttpGet]
        public IActionResult GetActiveDoctors()
        {
            var doctors = _doctorsData.GetActiveDoctors();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctorById([FromRoute] Guid id)
        {
            var doctor = _doctorsData.GetDoctorById(id);

            if (doctor == null || !doctor.IsActive)
            {
                return NotFound();
            }

            var response = new
            {
                Name = doctor.Name,
                LicenseNumber = doctor.LicenseNumber,
                SpecialityName = doctor.Speciality?.Name
            };

            return Ok(response);
        }

        [HttpGet]
        [Route("api/doctors/{id}")]
        public async Task<DoctorModel.Response>? GetDoctorById([FromRoute]Guid id) 
        {
            var doctor = _doctorsData.GetDoctorById(id);
            return new DoctorModel.Response(doctor.Name, doctor.LicenseNumber, doctor.Speciality.Name);
        }

            doctor.IsActive = false;

            return NoContent();
        }
    }
}