using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class User
    {
        public static int Id { get; set; }
        public static String Nombre { get; set; }
        public static String Nick { get; set; }
        public static String Password { get; set; }
        public static bool IsLogged { get; set; }
    }
}
