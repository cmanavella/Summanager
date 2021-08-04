using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Printer
    {
        public String Ip { get; set; }
        public String Estado { get; set; }
        public String Modelo { get; set; }
        public String Oficina { get; set; }
        public int ?Toner { get; set; }
        public int ?UImagen { get; set; }
        public int ?KitMant { get; set; }

        public static readonly string ONLINE = "Online";
        public static readonly string OFFLINE = "Offline";
        public static readonly string NO_ANALIZADA = "No Analizada";

        /** LEXMARK MS410 **/
        /// <summary>
        /// Lexmark MS410 Title.
        /// </summary>
        /// <remarks>
        /// Devuelve un string con lo quie figura en la etiqueta Title de la página HTML de una Impresora 
        /// Lexmark MS410.
        /// </remarks>
        public static readonly string L410_TITLE = "Lexmark MS410dn";
        /// <summary>
        /// Lexmark MS410 siguiente URL.
        /// </summary>
        /// <remarks>
        /// Devuelve un string para concatenar luego del IP de la Impresora Lexmark MS410. Es allí donde se encuentra
        /// el estado actual de su suministros.
        /// </remarks>
        public static readonly string L410_AFTER_URL = "/cgi-bin/dynamic/printer/PrinterStatus.html";
        /// <summary>
        /// Lexmark MS410 Table.
        /// </summary>
        /// <remarks>
        /// Devuelve un string con el nombre de la Etiqueta Table donde se deben buscar el estados de los suministros
        /// en la página de una Lexmark MS410.
        /// </remarks>
        public static readonly string L410_TABLE = "//table[@class='status_table']";
        /// <summary>
        /// Lexmark MS410 Table Number.
        /// </summary>
        /// <remarks>
        /// Devuelve, de acuerdo al suministro deseado, el número de órden de la tabla que lo almacena de la página de 
        /// una Impresora Lexmark MS410.
        /// </remarks>
        public enum L410_NUM_TABLA
        {
            TONER = 1,
            UNIDAD_IMAGEN = 4
        }
        /// <summary>
        /// Lexmark MS410 TR Number.
        /// </summary>
        /// <remarks>
        /// Devuelve, de acuerdo al suministro deseado, el número de órden de la Etiqueta TR que lo almacena de la página de 
        /// una Impresora Lexmark MS410.
        /// </remarks>
        public enum L410_NUM_TR
        {
            TONER = 3,
            UNIDAD_IMAGEN = 5
        }

        /**LEXMARK MS610 **/
        /// <summary>
        /// Lexmark MS610 Title.
        /// </summary>
        /// <remarks>
        /// Devuelve un string con lo quie figura en la etiqueta Title de la página HTML de una Impresora 
        /// Lexmark MS610.
        /// </remarks>
        public static readonly string L610_TITLE = "Lexmark MS610dn";
        /// <summary>
        /// Lexmark MS610 siguiente URL.
        /// </summary>
        /// <remarks>
        /// Devuelve un string para concatenar luego del IP de la Impresora Lexmark MS610. Es allí donde se encuentra
        /// el estado actual de su suministros.
        /// </remarks>
        public static readonly string L610_AFTER_URL = "/cgi-bin/dynamic/printer/PrinterStatus.html";
        /// <summary>
        /// Lexmark MS610 Table.
        /// </summary>
        /// <remarks>
        /// Devuelve un string con el nombre de la Etiqueta Table donde se deben buscar el estados de los suministros
        /// en la página de una Lexmark MS610.
        /// </remarks>
        public static readonly string L610_TABLE = "//table[@class='status_table']";
        /// <summary>
        /// Lexmark MS610 Table Number.
        /// </summary>
        /// <remarks>
        /// Devuelve, de acuerdo al suministro deseado, el número de órden de la tabla que lo almacena de la página de 
        /// una Impresora Lexmark MS610.
        /// </remarks>
        public enum L610_NUM_TABLA
        {
            TONER = 1,
            UNIDAD_IMAGEN = 4,
            KIT_MANTENIMIENTO = 4
        }
        /// <summary>
        /// Lexmark MS610 TR Number.
        /// </summary>
        /// <remarks>
        /// Devuelve, de acuerdo al suministro deseado, el número de órden de la Etiqueta TR que lo almacena de la página de 
        /// una Impresora Lexmark MS610.
        /// </remarks>
        public enum L610_NUM_TR
        {
            TONER = 3,
            UNIDAD_IMAGEN = 6,
            KIT_MANTENIMIENTO = 5
        }

        /** LEXMARK MS812 **/
        /// <summary>
        /// Lexmark MS812 Title.
        /// </summary>
        /// <remarks>
        /// Devuelve un string con lo quie figura en la etiqueta Title de la página HTML de una Impresora 
        /// Lexmark MS812.
        /// </remarks>
        public static readonly string L812_TITLE = "Lexmark MS812";
        /// <summary>
        /// Lexmark MS812 siguiente URL.
        /// </summary>
        /// <remarks>
        /// Devuelve un string para concatenar luego del IP de la Impresora Lexmark MS812. Es allí donde se encuentra
        /// el estado actual de su suministros.
        /// </remarks>
        public static readonly string L812_AFTER_URL = "/cgi-bin/dynamic/printer/PrinterStatus.html";
        /// <summary>
        /// Lexmark MS812 Table.
        /// </summary>
        /// <remarks>
        /// Devuelve un string con el nombre de la Etiqueta Table donde se deben buscar el estados de los suministros
        /// en la página de una Lexmark MS812.
        /// </remarks>
        public static readonly string L812_TABLE = "//table[@class='status_table']";
        /// <summary>
        /// Lexmark MS812 Table Number.
        /// </summary>
        /// <remarks>
        /// Devuelve, de acuerdo al suministro deseado, el número de órden de la tabla que lo almacena de la página de 
        /// una Impresora Lexmark MS812.
        /// </remarks>
        public enum L812_NUM_TABLA
        {
            TONER = 1,
            UNIDAD_IMAGEN = 4,
            KIT_MANTENIMIENTO = 4
        }
        /// <summary>
        /// Lexmark MS812 TR Number.
        /// </summary>
        /// <remarks>
        /// Devuelve, de acuerdo al suministro deseado, el número de órden de la Etiqueta TR que lo almacena de la página de 
        /// una Impresora Lexmark MS812.
        /// </remarks>
        public enum L812_NUM_TR
        {
            TONER = 3,
            UNIDAD_IMAGEN = 7,
            KIT_MANTENIMIENTO = 5
        }

        /** LEXMARK MS410 **/
        /// <summary>
        /// Lexmark MS410 Title.
        /// </summary>
        /// <remarks>
        /// Devuelve un string con lo quie figura en la etiqueta Title de la página HTML de una Impresora 
        /// Lexmark MS622.
        /// </remarks>
        public static readonly string L622_TITLE = "Lexmark MS622de";
    }
}
