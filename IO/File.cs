using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Configuration;

namespace IO
{
    public class File
    {
        /// <summary>
        /// Limpia la variable que almacena el Archivo Reciente.
        /// </summary>
        public static void ClearCurrentFile()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            settings["currentFile"].Value = "";

            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }

        /// <summary>
        /// Obtiene el Nombre del Archivo Reciente.
        /// </summary>
        /// <remarks>
        /// Si no hay ningún archivo reciente devuelve un String vacío.
        /// </remarks>
        /// <returns></returns>
        public static string GetCurrentFileTitle()
        {
            string retorno;
            string fileToRead = ConfigurationManager.AppSettings.Get("currentFile");

            retorno = fileToRead;

            return retorno;
        }

        /// <summary>
        /// Cambia la variable de configuración para que se almacene en ella la ruta del archivo abierto.
        /// </summary>
        /// <param name="filePath"></param>
        public static void openFile(string filePath)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            settings["currentFile"].Value = filePath;

            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }

        /// <summary>
        /// Guarda una Lista de Impresoras en una ruta determinada en un archivo con extensión SMP.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="printers"></param>
        public static void saveFileAs(string filePath, List<Printer> printers)
        {
            //Pregunto si la Lista no está vacía.
            if (printers.Count > 0)
            {
                //Pregunto si el archivo que quiero guardar existe. Si no, lo creo.
                if (!System.IO.File.Exists(filePath))
                {
                    var file = System.IO.File.Create(filePath);
                    file.Close();
                }

                //Escribo en el archivo.
                using(StreamWriter writerNewFile = new StreamWriter(filePath))
                {
                    //Write all IPs passed by the Parameters.
                    foreach(Printer printer in printers)
                    {
                        writerNewFile.WriteLine(printer.Ip);
                    }
                }

                //Guardo el archivo como reciente.
                openFile(filePath);
            }
        }

        /// <summary>
        /// Guarda una Lista de Impresoras en la ruta del archivo reciente.
        /// </summary>
        /// <param name="printers"></param>
        public static void saveFile(List<Printer> printers)
        {
            string filePath = ConfigurationManager.AppSettings.Get("currentFile");
            if (printers.Count > 0) //Me aseguro que la Lista no esté vacía.
            {
                using (StreamWriter writerNewFile = new StreamWriter(filePath))
                {
                    //Escribo el archivo.
                    foreach (Printer printer in printers)
                    {
                        writerNewFile.WriteLine(printer.Ip);
                    }
                }
            }
        }

        /// <summary>
        /// Importa datos de un archivo Excel.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<Printer> importExcelFile(string filePath)
        {
            List<Printer> retorno = new List<Printer>();

            Application application = new Application();
            //Abro un libro
            Workbook libros = application.Workbooks.Open(filePath);
            //Abro una hoja
            Worksheet hoja = (Worksheet)libros.Worksheets.Item[1];

            //Abro try para asegurarme que al final tanto el libro como la hoja son cerrados.
            try 
            {
                //Uso Range para acceder al archivo Excel.
                Range range = hoja.UsedRange;
                int row = 2; //Seteo como primera fila la 2 ya que la priemera están los Headers del archivo.
                //Uso la columna 1 como verificación, ya que muchas veces la columna usada para los Ip suele estar vacía
                //y uso la celda vacía para determinar que es el fin del archivo.
                string cellEval = (string)(range.Cells[row, 1]).Value2; 
                do 
                {
                    Printer printer = new Printer();
                    string ip = _makeIpAddress((string)(range.Cells[row, 8]).Value2); //Leo la columna donde se encuentran las Ips y las transformo en ellas.
                    if (_isValidIp(ip)) //Valido que la ip sea válida.
                    {
                        printer.Ip = ip; //Cargo la ip a un Objeto Impresora
                        printer.Estado = Printer.NO_ANALIZADA; //Seteo el estado del Objeto Impresora como No Analizada.
                        retorno.Add(printer); //Agrego la Impresora a la Lista de Retorno.
                    }
                    row++; //Cambio el contador de filas para pasar a la siguiente.
                    cellEval = (string)(range.Cells[row, 1]).Value2; //Obtengo el valor de siguiente fila. Siempre uso la columna 1 para comparar.
                } while (cellEval != null); //Pregunto si el valor devuelto no es nulo. Si no lo es, continúo con el bucle.
            }
            finally
            {
                //Finalmente cierro todo lo referido al archivo de Excel.
                libros.Close(true);
                application.Quit();
            }

            return retorno;
        }

        /// <summary>
        /// Comprueba que la Ip pasada por parámetro sea válida.
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        private static bool _isValidIp(string ip)
        {
            bool isValid = true; //Variable a devolver.
            string[] splitIp = ip.Split('.'); //Divido el string de ip en sus cuatro segmentos.
            if (splitIp.Length == 4) //Valido que haya cuatro segmentos.
            {
                for(int i=0; i < splitIp.Length; i++)
                {
                    if (Int32.Parse(splitIp[i]) < 0 || Int32.Parse(splitIp[i]) > 255) //Evalúo que cada uno de los segmentos se encuentren entre 0 y 255.
                    {
                        isValid = false; //Sino, la ip no es válida.
                        break; //Salgo del bucle.
                    }
                }
            }
            else
            {
                isValid = false; //Si el ip no tiene cuatro segmentos, no es válida.
            }
            return isValid;
        }

        /// <summary>
        /// Extrae solo una ip de una cadena de string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string _makeIpAddress(string value)
        {
            string retorno = "";
            char[] charsValue = value.ToCharArray(); //Armo un array de caracteres con la cadena de string para analizarlo caracter por caracter.

            //Busco las posiciones exactas de los puntos dentro del array y las guardo en una Lista.
            List<int> puntos = new List<int>();
            int i = 0;
            foreach(char c in charsValue)
            {
                if (c == '.') puntos.Add(i);
                i++;
            }

            //Valido que la lista tenga tres posiciones, eso quiere decir que hay tres puntos y hay una ip.
            if (puntos.Count == 3)
            {
                int firstPos = 0; //Almaceno la primera posición en el comienzo del Array
                int lastPos = charsValue.Length - 1; //Almaceno la última posición en el final del Array.

                //Analizo la posición del primer punto, y en base a eso retrocedo posiciones hasta no tener más dígitos numéricos.
                //Es ahí donde comienza la ip.
                for (int j = puntos[0]; j >= 0; j--)
                {
                    if (Char.IsDigit(charsValue[j]) || j == puntos[0])
                    {
                        firstPos = j;
                    }
                    else
                    {
                        break;
                    }
                }

                //Analizo la posición del último punto, y en base a eso avanzo posiciones hasta no tener más dígitos numéricos.
                //Es ahí donde finaliza la ip.
                for (int k = puntos[2]; k < charsValue.Length; k++)
                {
                    if (Char.IsDigit(charsValue[k]) || k == puntos[2])
                    {
                        lastPos = k;
                    }
                    else
                    {
                        break;
                    }
                }

                //Ya determinado las pocisiones de comienzo de la ip y de su final, armo un nuevo string con la ip.
                for(int l = firstPos; l <= lastPos; l++)
                {
                    retorno += charsValue[l];
                }
            }

            return retorno;
        }

        /// <summary>
        /// Exporta una Lista de Impresoras a un archivo Excel.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="printers"></param>
        public static void exportExcelFile(string filePath, List<Printer> printers)
        {
            Application application = new Application();
            //Abro un libro.
            Workbook libros = application.Workbooks.Add();
            //Abro una hoja.
            Worksheet hoja = (Worksheet) libros.Worksheets.Item[1];
            try
            {
                //Escribo las Cabeceras de Columnas.
                hoja.Cells[2, 2] = "Ip";
                hoja.Cells[2, 3] = "Modelo";
                hoja.Cells[2, 4] = "Estado";
                hoja.Cells[2, 5] = "Toner";
                hoja.Cells[2, 6] = "U. Img.";
                hoja.Cells[2, 7] = "Kit. Mant.";

                Range formatRange; //Creo un rango para dar formato a todo.

                //Doy formato a las Cabeceras de Columna y creo su borde externo.
                formatRange = hoja.Range["B2", "G2"];
                formatRange.Font.Bold = true;
                formatRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);
                formatRange.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(114, 159, 206));
                formatRange.Font.Color = ColorTranslator.ToOle(Color.White);

                //Cambio algunos anchos de Columna.
                hoja.Columns[2].ColumnWidth = 14;
                hoja.Columns[3].ColumnWidth = 17;
                hoja.Columns[4].ColumnWidth = 7;

                //Escribo cada una de las impresoras dentro de la Lista, comenzando en la Fila 3 ya que la 2 la uso para las Cabeceras.
                int contador = 3;
                foreach(Printer printer in printers)
                {
                    hoja.Cells[contador, 2] = printer.Ip.ToString();
                    formatRange = hoja.Cells[contador, 2];

                    if (printer.Modelo!=null) hoja.Cells[contador, 3] = printer.Modelo.ToString();
                    formatRange = hoja.Cells[contador, 3];

                    hoja.Cells[contador, 4] = printer.Estado.ToString();
                    formatRange = hoja.Cells[contador, 4];

                    if (printer.Toner != null) hoja.Cells[contador, 5] = printer.Toner.ToString() + "%";
                    formatRange = hoja.Cells[contador, 5];

                    if (printer.UImagen != null) hoja.Cells[contador, 6] = printer.UImagen.ToString() + "%";
                    formatRange = hoja.Cells[contador, 6];

                    if (printer.KitMant != null) hoja.Cells[contador, 7] = printer.KitMant.ToString() + "%";
                    formatRange = hoja.Cells[contador, 7];

                    //Doy formato a las filas de acuerdo al estado del suministro. Primero me aseguro que la impresora esté Online.
                    if (printer.Estado == "Online")
                    {
                        //Paint the the complete row as required
                        if(printer.Toner<=10 || printer.UImagen<=10 || (printer.KitMant!=null && printer.KitMant <= 10))
                        {
                            formatRange = hoja.Range[hoja.Cells[contador, 2], hoja.Cells[contador, 7]];
                            formatRange.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(255, 252, 204));
                        }
                        if (printer.Toner <= 3 || printer.UImagen <= 3 || (printer.KitMant != null && printer.KitMant <= 3))
                        {
                            formatRange = hoja.Range[hoja.Cells[contador, 2], hoja.Cells[contador, 7]];
                            formatRange.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(251, 207, 208));
                        }
                    }

                    contador++;
                }

                //Creo los bordes externos.
                string rangoFinal = "G" + (printers.Count + 2).ToString();
                formatRange = hoja.Range["B3", rangoFinal];
                formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);

                libros.SaveAs(filePath);
            }
            finally
            {
                //Finalmente cierro todo.
                libros.Close(true);
                application.Quit();
            }
        }
    }
}
