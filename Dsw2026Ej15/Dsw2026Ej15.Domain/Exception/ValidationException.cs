using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Domain.Exception
{
    public class ValidationException : System.Exception
    {
        public ValidationException(string msg) : base(msg) 
        {

        }
    }
}
