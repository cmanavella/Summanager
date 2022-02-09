using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CommonEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public CommonEntity(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

        public CommonEntity() : this(0, null) { }
    }
}
