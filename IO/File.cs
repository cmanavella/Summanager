using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
