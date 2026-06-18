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
        private readonly IPersistence _doctorsData;
        
        public DoctorController(IPersistence doctorsData)
        {
            _doctorsData = doctorsData;
        }

        [HttpPost]
        [Route("api/doctors")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] DoctorModel.Request request)
        {
            //validaciones acá por ahora. Más adelante, las validaciones estarán en una capa de aplicación (al menos aquellas que estén referidas al negocio)
            _doctorsData.AddDoctor(request);
            // return CreatedAtAction(nameof(Get), new { id = doctor.Id }, doctor);
            return Created();
        }

        [HttpGet]
        [Route("api/doctors")]
        public IEnumerable<Doctor> GetActiveDoctors() 
        {
            return _doctorsData.GetActiveDoctors();
        }

        [HttpGet]
        [Route("api/doctors/{id}")]
        public Doctor GetDoctorById([FromRoute]Guid id) 
        {
            return _doctorsData.GetDoctorById(id);
        }

    }
}
