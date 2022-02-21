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

        /// <summary>
        /// Devuelve un String con los Modelos de Impresoras Compatibles, separados por una coma.
        /// </summary>
        /// <returns>Un String con los Modelos de Impresoras Compatibles, separados por una coma.</returns>
        public string GetModelosToString()
        {
            //Creo el String de retorno como vacío.
            string modelos = String.Empty;
            //Creo una bandera para marcar el primer elemento.
            bool primera = true;

            //Recorro los Modelos de Impresoras del Suministro.
            foreach (Modelo modelo in this.Modelos)
            {
                //Si no es el primer Modelo, agrego una coma y un espacio al String de devolución.
                if (!primera) modelos += ", ";
                //Agrego el Nombre del Modelo al String de Devolución.
                modelos += modelo.Nombre;
                //Seteo la bandera que me indica que es el primer elemento en False, para que a partir de ahora me agregue siempre una
                //coma y un espacio en el String de Devolución.
                primera = false;
            }
            //Devuelvo el String.
            return modelos;
        }

        public override string ToString()
        {
            string modelos = "COMPATIBLE CON: " + GetModelosToString();

            return "CÓDIGO = " + this.Codigo.ToString() + " - NOMBRE = " + this.Nombre + " - " + this.Tipo.ToString() + "\n" +
                modelos;
        }
    }
}
