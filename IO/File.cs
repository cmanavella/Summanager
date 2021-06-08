﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO
{
    public class File
    {
        public static List<string> readIpFile()
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
                System.IO.File.Create(fileToRead);
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
    }
}
