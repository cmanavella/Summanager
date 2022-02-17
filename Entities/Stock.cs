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
    }
}
