using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Stock
    {
        public Suministro Suministro { get; set; }
        public int Alta { get; set; }
        public int Baja { get; set; }
        public int Fallado { get; set; }

        public Stock() : this(null, 0, 0, 0) { }

        public Stock(Suministro suministro, int alta, int baja, int fallado)
        {
            this.Suministro = suministro;
            this.Alta = alta;
            this.Baja = baja;
            this.Fallado = fallado;
        }

        public override string ToString()
        {
            return this.Suministro.ToString() + "\n" + "ALTA = " + this.Alta.ToString() + "\n" + "BAJA = " + this.Baja.ToString() + "\n" +
                "FALLADO = " + this.Fallado.ToString();
        }
    }
}
