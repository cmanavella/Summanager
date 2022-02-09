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
        public TipoSuministro Tipo { get; set; }
        public List<Modelo> Modelos { get; set; }

        public Suministro(Int64 codigo, String nombre, TipoSuministro tipo, List<Modelo> modelos)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Tipo = tipo;
            this.Modelos = modelos;
        }

        public Suministro(Int64 codigo, String nombre, List<Modelo> modelos)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Tipo = null;
            this.Modelos = modelos;
        }

        public Suministro(Int64 codigo, String nombre, TipoSuministro tipo)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Tipo = tipo;
            this.Modelos = null;
        }

        public Suministro(Int64 codigo, String nombre)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Tipo = null;
            this.Modelos = null;
        }

        public Suministro() : this(0, null, null, null) { }
    }
}
