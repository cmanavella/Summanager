using System;

namespace CustomExceptions
{
    public class SuministroException : Exception
    {
        public SuministroException() : base("No se puede acceder a uno o más suministros de la Impresora.") { }
    }
}
