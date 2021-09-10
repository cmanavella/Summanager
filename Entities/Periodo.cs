using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Periodo
    {
        /// <summary>
        /// Devuelve un período en segundos en base al valor de un Combo Período de Configuración.
        /// </summary>
        /// <param name="valorCombo"></param>
        /// <returns></returns>
        public static Int64 GetPeriodo(int valorCombo)
        {
            Int64 retorno = 0;

            switch (valorCombo)
            {
                case 1:
                    retorno = 60;
                    break;
                case 2:
                    retorno = 300;
                    break;
                case 3:
                    retorno = 600;
                    break;
                case 4:
                    retorno = 1200;
                    break;
                case 5:
                    retorno = 1800;
                    break;
                case 6:
                    retorno = 3600;
                    break;
                case 7:
                    retorno = 7200;
                    break;
                case 8:
                    retorno = 21600;
                    break;
                case 9:
                    retorno = 43200;
                    break;
                case 10:
                    retorno = 86400;
                    break;
                default:
                    retorno = 0;
                    break;
            }

            return retorno;
        }
    }
}
