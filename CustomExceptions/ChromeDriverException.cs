using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public class ChromeDriverException : Exception
    {
        public ChromeDriverException() : base("La versión de 'ChromeDriver' ha quedado obsoleta.") { }
    }
}
