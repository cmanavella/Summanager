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

            string fileToRead = AppDomain.CurrentDomain.BaseDirectory + "printers.cam";

            using (StreamReader reader = new StreamReader(fileToRead))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    retorno.Add(line);
                }
            }

            return retorno;
        }
    }
}
