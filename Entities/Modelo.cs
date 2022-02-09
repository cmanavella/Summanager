using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Modelo : CommonEntity
    {
        public static readonly int LEXMARK_410 = 1;
        public static readonly int LEXMARK_415 = 2;
        public static readonly int LEXMARK_610 = 3;
        public static readonly int LEXMARK_622 = 4;
        public static readonly int LEXMARK_812 = 5;
        public static readonly int HP_3015 = 6;

        public Modelo(int id, string nombre) : base(id, nombre) { }

        public Modelo() : base() { }
    }
}
