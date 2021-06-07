using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Printer
    {
        public String Modelo { get; set; }
        public int Toner { get; set; }
        public int UImagen { get; set; }
        public int ?KitMant { get; set; }
    }
}
