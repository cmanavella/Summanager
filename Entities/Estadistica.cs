using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Estadistica
    {
        public Estadistica()
        {
            Online = 0;
            Offline = 0;
            NoAnalizadas = 0;
            TonerRiesgo = 0;
            UnImgRiesgo = 0;
            KitMantRiesgo = 0;
            TonerCritico = 0;
            UnImgCritico = 0;
            KitMantCritico = 0;
        }

        public int Online { get; set; }
        public int Offline { get; set; }
        public int NoAnalizadas { get; set; }
        public int TonerRiesgo { get; set; }
        public int UnImgRiesgo { get; set; }
        public int KitMantRiesgo { get; set; }
        public int TonerCritico { get; set; }
        public int UnImgCritico { get; set; }
        public int KitMantCritico { get; set; }
    }
}
