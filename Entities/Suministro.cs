using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Suministro
    {
        public Int64 Codigo { get; set; }
        public String Nombre { get; set; }

        public Suministro(Int64 codigo, String nombre)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
        }

        public Suministro() : this(0, null) { }
    }
}
