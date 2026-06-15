using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Domain
{
    public class Doctor : BaseEntity
    {
        private string Name { get;}
        private string LicenseNumber { get; }
        private bool IsActive { get; set; }
        private Speciality Speciality { get; set; }
    }
}
