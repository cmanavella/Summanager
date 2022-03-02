using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public class LogInException : Exception
    {
        public LogInException() : base("El Nombre de Usuario o la Contraseña son incorrectos.") { }
    }
}
