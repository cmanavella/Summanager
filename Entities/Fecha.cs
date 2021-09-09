using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class Fecha
    {
        public static string ParceFecha(DateTime fecha)
        {
            return fecha.Day.ToString() + " de " + _ParceMes(fecha.Month) + " de " + fecha.Year.ToString() + 
                " " + fecha.Hour.ToString("00") + ":" + fecha.Minute.ToString("00") + ":" + fecha.Second.ToString("00");
        }

        private static string _ParceMes(int mes)
        {
            string retorno;
            switch (mes)
            {
                case 1:
                    retorno = "enero";
                    break;
                case 2:
                    retorno = "febrero";
                    break;
                case 3:
                    retorno = "marzo";
                    break;
                case 4:
                    retorno = "abril";
                    break;
                case 5:
                    retorno = "mayo";
                    break;
                case 6:
                    retorno = "junio";
                    break;
                case 7:
                    retorno = "julio";
                    break;
                case 8:
                    retorno = "agosto";
                    break;
                case 9:
                    retorno = "septiembre";
                    break;
                case 10:
                    retorno = "octubre";
                    break;
                case 11:
                    retorno = "noviembre";
                    break;
                case 12:
                    retorno = "diciembre";
                    break;
                default:
                    retorno = "enero";
                    break;
            }
            return retorno;
        }
    }
}
