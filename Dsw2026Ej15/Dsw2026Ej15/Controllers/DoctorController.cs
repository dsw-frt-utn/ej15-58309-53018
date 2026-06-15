using Microsoft.AspNetCore.Mvc;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Data.Interfaces;
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
        public void Post([FromBody] Doctor doctor) 
        {
            _doctorsData.AddDoctor(doctor);
        }

        [HttpGet]
        [Route("api/doctors")]
        public List<Doctor> Get() 
        {
            return _doctorsData.GetDoctors();
        }
    }
}
