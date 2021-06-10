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
        public int ?Toner { get; set; }
        public int ?UImagen { get; set; }
        public int ?KitMant { get; set; }

        public static readonly string ONLINE = "Online";

        /** LEXMARK MS410 **/
        public static readonly string L410_TITLE = "Lexmark MS410dn";
        public static readonly string L410_AFTER_URL = "/cgi-bin/dynamic/printer/PrinterStatus.html";
        public static readonly string L410_TABLE = "//table[@class='status_table']";
        public enum L410_NUM_TABLA
        {
            TONER = 1,
            UNIDAD_IMAGEN = 4
        }
        public enum L410_NUM_TR
        {
            TONER = 3,
            UNIDAD_IMAGEN = 5
        }
        
        /**LEXMARK MS610 **/
        public static readonly string L610_TITLE = "Lexmark MS610dn";
        public static readonly string L610_AFTER_URL = "/cgi-bin/dynamic/printer/PrinterStatus.html";
        public static readonly string L610_TABLE = "//table[@class='status_table']";
        public enum L610_NUM_TABLA
        {
            TONER = 1,
            UNIDAD_IMAGEN = 4,
            KIT_MANTENIMIENTO = 4
        }
        public enum L610_NUM_TR
        {
            TONER = 3,
            UNIDAD_IMAGEN = 6,
            KIT_MANTENIMIENTO = 5
        }

        /** LEXMARK MS812 **/
        public static readonly string L812_TITLE = "Lexmark MS812";
        public static readonly string L812_AFTER_URL = "/cgi-bin/dynamic/printer/PrinterStatus.html";
        public static readonly string L812_TABLE = "//table[@class='status_table']";
        public enum L812_NUM_TABLA
        {
            TONER = 1,
            UNIDAD_IMAGEN = 4,
            KIT_MANTENIMIENTO = 4
        }
        public enum L812_NUM_TR
        {
            TONER = 3,
            UNIDAD_IMAGEN = 7,
            KIT_MANTENIMIENTO = 5
        }
    }
}
