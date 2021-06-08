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
    }
}
