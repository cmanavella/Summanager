using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

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
                hoja.Cells[1, 1] = "Ip";
                hoja.Cells[1, 2] = "Modelo";
                hoja.Cells[1, 3] = "Estado";
                hoja.Cells[1, 4] = "Toner";
                hoja.Cells[1, 5] = "U. Img.";
                hoja.Cells[1, 6] = "Kit. Mant.";

                int contador = 2;
                foreach(Printer printer in printers)
                {
                    hoja.Cells[contador, 1] = printer.Ip.ToString();
                    if(printer.Modelo!=null) hoja.Cells[contador, 2] = printer.Modelo.ToString();
                    hoja.Cells[contador, 3] = printer.Estado.ToString();
                    if (printer.Toner != null) hoja.Cells[contador, 4] = printer.Toner.ToString() + "%";
                    if (printer.UImagen != null) hoja.Cells[contador, 5] = printer.UImagen.ToString() + "%";
                    if (printer.KitMant != null) hoja.Cells[contador, 6] = printer.KitMant.ToString() + "%";

                    contador++;
                }

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
