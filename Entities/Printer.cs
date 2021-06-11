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

        /// <summary>
        /// Online Printer State.
        /// </summary>
        /// <remarks>
        /// Return a String with Online Printer State, used inside all the System.
        /// </remarks>
        public static readonly string ONLINE = "Online";

        /** LEXMARK MS410 **/
        /// <summary>
        /// Lexmark MS410 Title.
        /// </summary>
        /// <remarks>
        /// Returns a String like Lexmark MS410 HTML Page Title is.
        /// </remarks>
        public static readonly string L410_TITLE = "Lexmark MS410dn";
        /// <summary>
        /// Lexmark MS410 After URL.
        /// </summary>
        /// <remarks>
        /// Returns a String to concat after the printer IP. In this page, it's the rest of Printer Information.
        /// </remarks>
        public static readonly string L410_AFTER_URL = "/cgi-bin/dynamic/printer/PrinterStatus.html";
        /// <summary>
        /// Lexmark MS410 Table.
        /// </summary>
        /// <remarks>
        /// Returns a String with the table name where the Printer Results are.
        /// </remarks>
        public static readonly string L410_TABLE = "//table[@class='status_table']";
        /// <summary>
        /// Lexmark MS410 Table Number.
        /// </summary>
        /// <remarks>
        /// Returns the number of the Tag Table where we find results.
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
        /// Returns the number of the Tag TR where we find results.
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
        /// Returns a String like Lexmark MS610 HTML Page Title is.
        /// </remarks>
        public static readonly string L610_TITLE = "Lexmark MS610dn";
        /// <summary>
        /// Lexmark MS610 After URL.
        /// </summary>
        /// <remarks>
        /// Returns a String to concat after the printer IP. In this page, it's the rest of Printer Information.
        /// </remarks>
        public static readonly string L610_AFTER_URL = "/cgi-bin/dynamic/printer/PrinterStatus.html";
        /// <summary>
        /// Lexmark MS610 Table.
        /// </summary>
        /// <remarks>
        /// Returns a String with the table name where the Printer Results are.
        /// </remarks>
        public static readonly string L610_TABLE = "//table[@class='status_table']";
        /// <summary>
        /// Lexmark MS610 Table Number.
        /// </summary>
        /// <remarks>
        /// Returns the number of the Tag Table where we find results.
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
        /// Returns the number of the Tag TR where we find results.
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
        /// Returns a String like Lexmark MS812 HTML Page Title is.
        /// </remarks>
        public static readonly string L812_TITLE = "Lexmark MS812";
        /// <summary>
        /// Lexmark MS610 After URL.
        /// </summary>
        /// <remarks>
        /// Returns a String to concat after the printer IP. In this page, it's the rest of Printer Information.
        /// </remarks>
        public static readonly string L812_AFTER_URL = "/cgi-bin/dynamic/printer/PrinterStatus.html";
        /// <summary>
        /// Lexmark MS812 Table.
        /// </summary>
        /// <remarks>
        /// Returns a String with the table name where the Printer Results are.
        /// </remarks>
        public static readonly string L812_TABLE = "//table[@class='status_table']";
        /// <summary>
        /// Lexmark MS812 Table Number.
        /// </summary>
        /// <remarks>
        /// Returns the number of the Tag Table where we find results.
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
        /// Returns the number of the Tag TR where we find results.
        /// </remarks>
        public enum L812_NUM_TR
        {
            TONER = 3,
            UNIDAD_IMAGEN = 7,
            KIT_MANTENIMIENTO = 5
        }
    }
}
