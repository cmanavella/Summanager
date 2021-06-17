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
        /// Read current.smp file.
        /// </summary>
        /// <remarks>
        /// Open, read and after returns a List of Strings with all IPs within Current File.
        /// </remarks>
        /// <returns>List of String</returns>
        public static List<Printer> readCurrentFile()
        {
            //Make a Return Variable. It's a List of Strings.
            List<Printer> retorno = new List<Printer>();

            //Load the Path and File Name where Current File is.
            string fileToRead = ConfigurationManager.AppSettings.Get("currentFile");

            //Ask if the Current File exist.
            if (System.IO.File.Exists(fileToRead))
            {
                //If it exist. I read it.
                using (StreamReader reader = new StreamReader(fileToRead))
                {
                    Printer printer;
                    string line;
                    //While I find a new line within the Current File, I load it inside a String.
                    while ((line = reader.ReadLine()) != null)
                    {
                        if(!(line.Substring(0,1)=="[" && line.Substring(line.Length - 1, 1) == "]"))
                        {
                            printer = new Printer();
                            printer.Ip = line;
                            //Add Line read inside Return Variable.
                            retorno.Add(printer);
                        }
                    }
                }
            }

            return retorno;
        }

        public static string GetCurrentFileTitle()
        {
            string retorno;
            string fileToRead = ConfigurationManager.AppSettings.Get("currentFile");

            retorno = fileToRead;

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
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            settings["currentFile"].Value = filePath;

            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }

        /// <summary>
        /// Save a SMP File.
        /// </summary>
        /// <remarks>
        /// Allow save the Information within the Current File inside a SMP File.
        /// </remarks>
        /// <param name="filePath"></param>
        /// <param name="ips"></param>
        public static void saveFile(string filePath, List<Printer> printers)
        {
            //Ask for List of String that contain the IPs to ensure that it has more than 0 count.
            if (printers.Count > 0)
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
                    //Write all IPs passed by the Parameters.
                    foreach(Printer printer in printers)
                    {
                        writerNewFile.WriteLine(printer.Ip);
                    }
                }

                openFile(filePath);
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
        public static List<Printer> importExcelFile(string filePath)
        {
            List<Printer> retorno = new List<Printer>();

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
                string cellEval = (string)(range.Cells[row, 1]).Value2; //Get the first Excel data.
                do 
                {
                    Printer printer = new Printer();
                    string ip = _makeIpAddress((string)(range.Cells[row, 8]).Value2); //Convert the Excel value in a ip.
                    if (_isValidIp(ip))
                    {
                        printer.Ip = ip;
                        retorno.Add(printer); //If the ip is valid, add it to the return variable.
                    }
                    row++; //Add one to the Row counter.
                    cellEval = (string)(range.Cells[row, 1]).Value2; //Get the next Excel Data.
                } while (cellEval != null); //Do all while Excel Data is not null.
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
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
            string retorno = "";
            char[] charsValue = value.ToCharArray();

            //Find the dot positions in array char from string, and save it.
            List<int> puntos = new List<int>();
            int i = 0;
            foreach(char c in charsValue)
            {
                if (c == '.') puntos.Add(i);
                i++;
            }

            //If the List of dots has 3 items means there is an ip.
            if (puntos.Count == 3)
            {
                int firstPos = 0;
                int lastPos = charsValue.Length - 1;

                //Analyze the first item of the List and determine wich is the first position of the first segment
                //of ip in char array.
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

                //Analyze the last item of the List and determine wich is the last position of the last segment
                //of ip in char array.
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

                //Make an ip whith the chars.
                for(int l = firstPos; l <= lastPos; l++)
                {
                    retorno += charsValue[l];
                }
            }

            return retorno;
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

                //Make the Columns Headers external borders.
                formatRange = hoja.Range["B2", "G2"];
                formatRange.Font.Bold = true;
                formatRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);
                formatRange.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(114, 159, 206));
                formatRange.Font.Color = ColorTranslator.ToOle(Color.White);

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
                    //formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);

                    if (printer.Modelo!=null) hoja.Cells[contador, 3] = printer.Modelo.ToString();
                    formatRange = hoja.Cells[contador, 3];
                    //formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);

                    hoja.Cells[contador, 4] = printer.Estado.ToString();
                    formatRange = hoja.Cells[contador, 4];
                    //formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);

                    if (printer.Toner != null) hoja.Cells[contador, 5] = printer.Toner.ToString() + "%";
                    formatRange = hoja.Cells[contador, 5];
                    //formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);

                    if (printer.UImagen != null) hoja.Cells[contador, 6] = printer.UImagen.ToString() + "%";
                    formatRange = hoja.Cells[contador, 6];
                    //formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);

                    if (printer.KitMant != null) hoja.Cells[contador, 7] = printer.KitMant.ToString() + "%";
                    formatRange = hoja.Cells[contador, 7];
                    //formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);

                    //Ask for the Printer State. It must Online.
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
