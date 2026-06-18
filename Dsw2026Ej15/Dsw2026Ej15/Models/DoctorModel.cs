namespace Dsw2026Ej15.Api.Models
{
    internal record DoctorModel
    {
        public record Request(string Name, string LicenseNumber, Guid SpecialityId);
        public record Response();
    }
}
