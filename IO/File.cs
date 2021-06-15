using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Drawing;

namespace IO
{
    public class File
    {
        /// <summary>
        /// Read current.smp file.
        /// </summary>
        /// <remarks>
        /// Open, read and after returns a List of Strings with all IPs within Current File.
        /// </remarks>
        /// <returns>List of String</returns>
        public static List<string> readCurrentFile()
        {
            //Make a Return Variable. It's a List of Strings.
            List<string> retorno = new List<string>();

            //Load the Path and File Name where Current File is.
            string fileToRead = AppDomain.CurrentDomain.BaseDirectory + "current.smp";

            //Ask if the Current File exist.
            if (System.IO.File.Exists(fileToRead))
            {
                //If it exist. I read it.
                using (StreamReader reader = new StreamReader(fileToRead))
                {
                    string line;
                    //While I find a new line within the Current File, I load it inside a String.
                    while ((line = reader.ReadLine()) != null)
                    {
                        //Add Line read inside Return Variable.
                        retorno.Add(line);
                    }
                }
            }
            else
            {
                //If the Current File don't exist, I must creat it.
                var file = System.IO.File.Create(fileToRead);
                file.Close(); //Close it.

                //Open it again to add just the Title inside.
                using (StreamWriter writer = new StreamWriter(fileToRead))
                {
                    string titulo = "[sin título]";
                    writer.WriteLine(titulo);
                    retorno.Add(titulo);
                }
            }

            return retorno;
        }

        /// <summary>
        /// Open a SMP File.
        /// </summary>
        /// <remarks>
        /// Open a SMP File for its use inside the System.
        /// </remarks>
        /// <param name="filePath"></param>
        public static void openFile(string filePath)
        {
            //Make a List of String for save all the File Content.
            List<string> ips = new List<string>();

            //Read the File and save the information saved within the File.
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    ips.Add(line);
                }
            }

            writeCurrentFile(ips);
        }

        /// <summary>
        /// Write the Current File with a List of Ips.
        /// </summary>
        /// <param name="ips"></param>
        public static void writeCurrentFile(List<string> ips)
        {
            //Open the Current File and load it with the Opened File Information.
            string currentFile = AppDomain.CurrentDomain.BaseDirectory + "current.smp";
            using (StreamWriter writerCurrentFile = new StreamWriter(currentFile))
            {
                foreach (string ip in ips)
                {
                    writerCurrentFile.WriteLine(ip);
                }
            }
        }

        /// <summary>
        /// Write the Current File with a List of Ips and a Title.
        /// </summary>
        /// <param name="ips"></param>
        /// <param name="title"></param>
        public static void writeCurrentFile(List<string> ips, string title)
        {
            //Open the Current File and load it with the Opened File Information.
            string currentFile = AppDomain.CurrentDomain.BaseDirectory + "current.smp";
            using (StreamWriter writerCurrentFile = new StreamWriter(currentFile))
            {
                writerCurrentFile.WriteLine(title);
                foreach (string ip in ips)
                {
                    writerCurrentFile.WriteLine(ip);
                }
            }
        }

        /// <summary>
        /// Save a SMP File.
        /// </summary>
        /// <remarks>
        /// Allow save the Information within the Current File inside a SMP File.
        /// </remarks>
        /// <param name="filePath"></param>
        /// <param name="ips"></param>
        public static void saveFile(string filePath, List<string> ips)
        {
            //Split the File Path with its File Name for use the File Name as the File Title.
            string[] path = filePath.Split('\\');
            //Use the last Array of splited Path and cut it removing its extension.
            string titulo = path[path.Length - 1].Substring(0, path[path.Length - 1].Length-4);

            //Ask for List of String that contain the IPs to ensure that it has more than 0 count.
            if (ips.Count > 0)
            {
                //Ask if the File exist. If not, I creat it.
                if (!System.IO.File.Exists(filePath))
                {
                    var file = System.IO.File.Create(filePath);
                    file.Close();
                }

                //Write the File.
                using(StreamWriter writerNewFile = new StreamWriter(filePath))
                {
                    //Write the File Title at the first line.
                    writerNewFile.WriteLine("[" + titulo + "]");

                    //Write all IPs passed by the Parameters.
                    foreach(string ip in ips)
                    {
                        writerNewFile.WriteLine(ip);
                    }
                }

                //Open the Current File and overwrite it with the saved File Information.
                string currentFile = AppDomain.CurrentDomain.BaseDirectory + "current.smp";
                using (StreamWriter writerCurrentFile = new StreamWriter(currentFile))
                {
                    writerCurrentFile.WriteLine("[" + titulo + "]");

                    foreach (string ip in ips)
                    {
                        writerCurrentFile.WriteLine(ip);
                    }
                }
            }
        }

        /// <summary>
        /// Import an Excel File.
        /// </summary>
        /// <remarks>
        /// Import an Excel File with a list of Pinters inside into a List of Printers.
        /// </remarks>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<string> importExcelFile(string filePath)
        {
            List<string> retorno = new List<string>();

            Application application = new Application();
            //Open a book
            Workbook libros = application.Workbooks.Open(filePath);
            //Open a sheet
            Worksheet hoja = (Worksheet)libros.Worksheets.Item[1];

            try
            {
                //Use a Range to access to Excel File.
                Range range = hoja.UsedRange;
                int row = 2; //Start with the second Row because the first one is used to the Column Headers.
                string excelValue = (string)(range.Cells[row, 8]).Value2; //Get the first Excel data.
                do 
                {
                    string ip = _makeIpAddress(excelValue); //Convert the Excel value in a ip.
                    if (_isValidIp(ip)) retorno.Add(ip); //If the ip is valid, add it to the return variable.
                    row++; //Add one to the Row counter.
                    excelValue = (string)(range.Cells[row, 8]).Value2; //Get the next Excel Data.
                } while (excelValue != null); //Do all while Excel Data is not null.
            }
            finally
            {
                //Finally close the Excel File.
                libros.Close(true);
                application.Quit();
            }

            return retorno;
        }

        /// <summary>
        /// Is Valid Ip
        /// </summary>
        /// <remarks>
        /// Evaluate if the Ip passing by parameter is Valid.
        /// </remarks>
        /// <param name="ip"></param>
        /// <returns></returns>
        private static bool _isValidIp(string ip)
        {
            bool isValid = true; //Variable to return
            string[] splitIp = ip.Split('.'); //Split the string ip in each ip segment.
            if (splitIp.Length == 4) //If the ip have 4 segments is valid.
            {
                for(int i=0; i < splitIp.Length; i++)
                {
                    if (Int32.Parse(splitIp[i]) < 0 || Int32.Parse(splitIp[i]) > 255) //Evaluate each ip segment is between 0 and 255.
                    {
                        isValid = false; //If not, the ip is not valid.
                        i = splitIp.Length;
                    }
                }
            }
            else
            {
                isValid = false; //If the ip have not 4 segment is not valid.
            }
            return isValid;
        }

        /// <summary>
        /// Construct an Ip address with a String.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string _makeIpAddress(string value)
        {
            string[] splitValue = value.Split(' ');
            return splitValue[0];
        }

        /// <summary>
        /// Export Analyzed Printer Information in an Excel File.
        /// </summary>
        /// <remarks>
        /// Take all the Analyzed Printer Information and make a new Excel File with.
        /// </remarks>
        /// <param name="filePath"></param>
        /// <param name="printers"></param>
        public static void exportExcelFile(string filePath, List<Printer> printers)
        {
            Application application = new Application();
            //Make a book.
            Workbook libros = application.Workbooks.Add();
            //Make a sheet
            Worksheet hoja = (Worksheet) libros.Worksheets.Item[1];
            try
            {
                //Write the Columns Headers
                hoja.Cells[2, 2] = "Ip";
                hoja.Cells[2, 3] = "Modelo";
                hoja.Cells[2, 4] = "Estado";
                hoja.Cells[2, 5] = "Toner";
                hoja.Cells[2, 6] = "U. Img.";
                hoja.Cells[2, 7] = "Kit. Mant.";

                Range formatRange; //Element for formating the cells.
                //Make the Columns Headers internal borders.
                for (int i=2; i<=7; i++)
                {
                    formatRange = hoja.Cells[2, i];
                    formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);
                }
                //Make the Columns Headers external borders.
                formatRange = hoja.Range["B2", "G2"];
                formatRange.Font.Bold = true;
                formatRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);

                //Change some Column Width as I required.
                hoja.Columns[2].ColumnWidth = 14;
                hoja.Columns[3].ColumnWidth = 17;
                hoja.Columns[4].ColumnWidth = 7;

                //Write each printer inside the Excel File and format it.
                int contador = 3;
                foreach(Printer printer in printers)
                {
                    //Write the Information and make the internar border of each cell.
                    hoja.Cells[contador, 2] = printer.Ip.ToString();
                    formatRange = hoja.Cells[contador, 2];
                    formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);

                    if (printer.Modelo!=null) hoja.Cells[contador, 3] = printer.Modelo.ToString();
                    formatRange = hoja.Cells[contador, 3];
                    formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);

                    hoja.Cells[contador, 4] = printer.Estado.ToString();
                    formatRange = hoja.Cells[contador, 4];
                    formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);

                    if (printer.Toner != null) hoja.Cells[contador, 5] = printer.Toner.ToString() + "%";
                    formatRange = hoja.Cells[contador, 5];
                    formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);

                    if (printer.UImagen != null) hoja.Cells[contador, 6] = printer.UImagen.ToString() + "%";
                    formatRange = hoja.Cells[contador, 6];
                    formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);

                    if (printer.KitMant != null) hoja.Cells[contador, 7] = printer.KitMant.ToString() + "%";
                    formatRange = hoja.Cells[contador, 7];
                    formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);

                    //Ask for the Printer State. It must Online.
                    if (printer.Estado == "Online")
                    {
                        //Paint the the complete row as required
                        if(printer.Toner<=10 || printer.UImagen<=10 || (printer.KitMant!=null && printer.KitMant <= 10))
                        {
                            formatRange = hoja.Range[hoja.Cells[contador, 2], hoja.Cells[contador, 7]];
                            formatRange.Interior.Color = ColorTranslator.ToOle(Color.Yellow);
                        }
                        if (printer.Toner <= 3 || printer.UImagen <= 3 || (printer.KitMant != null && printer.KitMant <= 3))
                        {
                            formatRange = hoja.Range[hoja.Cells[contador, 2], hoja.Cells[contador, 7]];
                            formatRange.Interior.Color = ColorTranslator.ToOle(Color.Red);
                        }
                    }

                    contador++;
                }

                //Make the externar border.
                string rangoFinal = "G" + (printers.Count + 2).ToString();
                formatRange = hoja.Range["B3", rangoFinal];
                formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);

                libros.SaveAs(filePath);
            }
            finally
            {
                //Finally close the Excel File.
                libros.Close(true);
                application.Quit();
            }
        }
    }
}
