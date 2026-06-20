using Microsoft.AspNetCore.Mvc;
using Dsw2026Ej15.Data.Interfaces;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Api.Models;
using Dsw2026Ej15.Domain.Exceptions;

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
            var speciality = _doctorsData.GetSpecialityById(request.SpecialityId);

            if (string.IsNullOrWhiteSpace(request.Name) ||
            string.IsNullOrWhiteSpace(request.LicenseNumber))
            {
                throw new ValidationException("No se permiten campos vacíos");
            }
            if (speciality is null) throw new ValidationException("No existe la especialidad indicada");

            var newDoctor = new Doctor(request.Name, request.LicenseNumber, speciality);

            _doctorsData.AddDoctor(newDoctor);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetActiveDoctors()
        {
            var doctors = _doctorsData.GetActiveDoctors();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById([FromRoute] Guid id)
        {
            var doctor = _doctorsData.GetDoctorById(id);

            if (doctor == null! || doctor.IsActive) 
            {
                return NotFound("El ID ingresado no corresponde a un doctor registrado/activo.");
            }

            var response = new DoctorModel.Response(doctor.Name, doctor.LicenseNumber, doctor.Speciality.Name);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var doctor = _doctorsData.GetDoctorById(id);

            if (doctor == null || !doctor.IsActive)
            {
                return NotFound();
            }

            doctor.IsActive = false;

            return NoContent();
        }
    }
}
