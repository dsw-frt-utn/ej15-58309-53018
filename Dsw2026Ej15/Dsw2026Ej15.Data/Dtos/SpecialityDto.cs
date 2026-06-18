using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Data.Dtos
{
    internal class SpecialityDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
