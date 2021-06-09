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
        public static List<string> readCurrentFile()
        {
            List<string> retorno = new List<string>();

            string fileToRead = AppDomain.CurrentDomain.BaseDirectory + "current.smp";

            if (System.IO.File.Exists(fileToRead))
            {
                using (StreamReader reader = new StreamReader(fileToRead))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        retorno.Add(line);
                    }
                }
            }
            else
            {
                var file = System.IO.File.Create(fileToRead);
                file.Close();

                using (StreamWriter writer = new StreamWriter(fileToRead))
                {
                    string titulo = "[sin título]";
                    writer.WriteLine(titulo);
                    retorno.Add(titulo);
                }
            }

            return retorno;
        }

        public static StreamWriter openLogFile()
        {
             
            string fileToWrite = AppDomain.CurrentDomain.BaseDirectory + "events.log";
            List<string> lineas = new List<string>();

            if (System.IO.File.Exists(fileToWrite))
            {
                using (StreamReader reader = new StreamReader(fileToWrite))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lineas.Add(line);
                    }
                }
            }
            else
            {
                var file = System.IO.File.Create(fileToWrite);
                file.Close();
            }

            StreamWriter writer = new StreamWriter(fileToWrite);
            if (lineas.Count > 0)
            {
                foreach(string line in lineas)
                {
                    writer.WriteLine(line);
                }
            }

            return writer;
        }

        public static void closeLogFile(StreamWriter writer)
        {
            writer.Close();
        }

        public static void openFile(string filePath)
        {
            List<string> ips = new List<string>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    ips.Add(line);
                }
            }

            string currentFile = AppDomain.CurrentDomain.BaseDirectory + "current.smp";
            using (StreamWriter writerCurrentFile = new StreamWriter(currentFile))
            {
                foreach (string ip in ips)
                {
                    writerCurrentFile.WriteLine(ip);
                }
            }
        }

        public static void saveFile(string filePath, List<string> ips)
        {
            string[] path = filePath.Split('\\');
            string titulo = path[path.Length - 1].Substring(0, path[path.Length - 1].Length-4);

            if (ips.Count > 0)
            {
                if (!System.IO.File.Exists(filePath))
                {
                    var file = System.IO.File.Create(filePath);
                    file.Close();
                }

                using(StreamWriter writerNewFile = new StreamWriter(filePath))
                {
                    writerNewFile.WriteLine("[" + titulo + "]");

                    foreach(string ip in ips)
                    {
                        writerNewFile.WriteLine(ip);
                    }
                }

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

        public static void exportExcelFile(string filePath, List<Printer> printers)
        {
            Application application = new Application();
            Workbook libros = application.Workbooks.Add();
            Worksheet hoja = (Worksheet) libros.Worksheets.Item[1];
            try
            {
                hoja.Cells[2, 2] = "Ip";
                hoja.Cells[2, 3] = "Modelo";
                hoja.Cells[2, 4] = "Estado";
                hoja.Cells[2, 5] = "Toner";
                hoja.Cells[2, 6] = "U. Img.";
                hoja.Cells[2, 7] = "Kit. Mant.";

                Range formatRange;
                for (int i=2; i<=7; i++)
                {
                    formatRange = hoja.Cells[2, i];
                    formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);
                }
                formatRange = hoja.Range["B2", "G2"];
                formatRange.Font.Bold = true;
                formatRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);

                hoja.Columns[2].ColumnWidth = 14;
                hoja.Columns[3].ColumnWidth = 17;
                hoja.Columns[4].ColumnWidth = 7;

                int contador = 3;
                foreach(Printer printer in printers)
                {
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

                    if (printer.Estado == "Online")
                    {
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

                string rangoFinal = "G" + (printers.Count + 2).ToString();
                formatRange = hoja.Range["B3", rangoFinal];
                formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);

                libros.SaveAs(filePath);
            }
            finally
            {
                libros.Close(true);
                application.Quit();
            }
        }
    }
}
