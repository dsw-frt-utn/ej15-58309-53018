using Microsoft.AspNetCore.Mvc;
using Dsw2026Ej15.Data.Interfaces;
using Dsw2026Ej15.Data.Dtos;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Api.Models;
namespace Dsw2026Ej15.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        
        public DoctorController()
        {
        }

        [HttpPost]
        [Route("api/doctors")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] DoctorModel.Request request, [FromServices] IPersistence doctorsData)
        {
            //validaciones acá por ahora. Más adelante, las validaciones estarán en una capa de aplicación (al menos aquellas que estén referidas al negocio)
            doctorsData.AddDoctor(doctor);
            // return CreatedAtAction(nameof(Get), new { id = doctor.Id }, doctor);
            return Created();
        }

        [HttpGet]
        [Route("api/doctors")]
        public IEnumerable<Doctor> GetActiveDoctors([FromServices] IPersistence doctorsData) 
        {
            return doctorsData.GetActiveDoctors();
        }

        [HttpGet]
        [Route("api/doctors/{id}")]
        public Doctor GetDoctorById([FromRoute]Guid id, [FromServices] IPersistence doctorsData) 
        {
            return doctorsData.GetDoctorById(id);
        }

    }
}
