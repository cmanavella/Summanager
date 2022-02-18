﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public class SuministroNoEncontradoException : Exception
    {
        public SuministroNoEncontradoException() : base("No se ha encontrado el Suministro en la Base de Datos.") { }
    }
}
