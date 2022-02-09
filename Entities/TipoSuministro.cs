using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TipoSuministro : CommonEntity
    {
        public static readonly int TONER = 1;
        public static readonly int UNIDAD_IMAGEN = 2;

        public TipoSuministro(int id, string nombre) : base(id, nombre){}

        public TipoSuministro() : base() { }
    }
}
