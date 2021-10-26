﻿using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Configuration;
using System.Data;
using DataTable = System.Data.DataTable;
using DataRow = System.Data.DataRow;

namespace IO
{
    public class File
    {
        /// <summary>
        /// Busca en el Archivo de Configuración si está activada la opción de Actualización Automática de Estados de Impresoras.
        /// </summary>
        /// <returns></returns>
        public static bool getActualizacionEstados()
        {
            bool retorno = false;

            //Traigo el string de la variable almacenada en el Archivo de Configuración.
            string cmstr = ConfigurationManager.AppSettings.Get("actualizarEstados");

            //Si no está vacío convierto ese string en bool.
            if (cmstr != null && cmstr == "true") retorno = true;

            return retorno;
        }

        /// <summary>
        /// Almacena en el Archivo de Configuración el estado de la opción de Actualización Automática de Estados de Impresoras.
        /// </summary>
        /// <returns></returns>
        public static void setActualizacionEstados(bool estado)
        {
            string strEstado;

            //Convierto el bool a string.
            if (estado)
            {
                strEstado = "true";
            }
            else
            {
                strEstado = "false";
            }

            //Cambio la variable almacenada en el Archivo de Configuración.
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //En esta parte abro la sección settings para verificar que la variable existe.
            AppSettingsSection section = (AppSettingsSection)configFile.GetSection("appSettings");
            KeyValueConfigurationCollection app_settings = section.Settings;
            KeyValueConfigurationElement key = app_settings["actualizarEstados"];
            if(key == null) //Si la variable no existe, la creo.
            {
                KeyValueConfigurationElement new_key = new KeyValueConfigurationElement("actualizarEstados", strEstado);
                app_settings.Add(new_key);
            }
            else //Si existe la guardo.
            {
                var settings = configFile.AppSettings.Settings;
                settings["actualizarEstados"].Value = strEstado;
            }

            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }

        /// <summary>
        /// Busca en el Archivo de Configuración el período de Actualización Automática de Estados de Impresoras.
        /// </summary>
        /// <returns></returns>
        public static int getPeriodo()
        {
            int periodo = 0;

            //Traigo el string de la variable almacenada en el Archivo de Configuración.
            string cmstr = ConfigurationManager.AppSettings.Get("periodoActualizacion");

            //Si la variable no está vacía la convierto en string.
            if (cmstr != null)
            {
                if(cmstr.Length > 0) periodo = Int32.Parse(cmstr);
            }

            return periodo;
        }

        /// <summary>
        /// Almacena en el Archivo de Configuración el período de Actualización Automática de Estados de Impresoras.
        /// </summary>
        /// <returns></returns>
        public static void setPeriodo(int periodo)
        {
            //Cambio la variable almacenada en el Archivo de Configuración.
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //En esta parte abro la sección settings para verificar que la variable existe.
            AppSettingsSection section = (AppSettingsSection)configFile.GetSection("appSettings");
            KeyValueConfigurationCollection app_settings = section.Settings;
            KeyValueConfigurationElement key = app_settings["periodoActualizacion"];
            if (key == null) //Si la variable no existe, la creo.
            {
                KeyValueConfigurationElement new_key = new KeyValueConfigurationElement("periodoActualizacion", periodo.ToString());
                app_settings.Add(new_key);
            }
            else //Si existe la guardo.
            {
                var settings = configFile.AppSettings.Settings;
                settings["periodoActualizacion"].Value = periodo.ToString();
            }
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }

        /// <summary>
        /// Lee el archivo reciente con la extensión SMP cuya ruta está almacenda en el
        /// Application Config.
        /// </summary>
        public static List<Printer> readCurrentFile()
        {
            List<Printer> retorno = new List<Printer>();

            //Cargo la ruta del archivo reciente.
            string fileToRead = ConfigurationManager.AppSettings.Get("currentFile");

            //Pregunto si el archivo existe.
            if (System.IO.File.Exists(fileToRead))
            {
                string cadena = _desencriptar(fileToRead); //Desencripto el archivo.

                //Separo la cadena por sus saltos de líneas en un array de strings.
                string[] splitLinea = cadena.Split('\n');
                //Recorro cada elemento separado de la cadena.
                foreach(string linea in splitLinea)
                {
                    //Divido el elemento split nuevamente ya que en él se guarda el Ip y la Oficina.
                    string[] elemento = linea.Split('\\');
                    Printer printer = new Printer();
                    printer.Ip = elemento[0]; //Cargo el ip almacenado con el string leído actualmente. Ese valor es la Ip.
                    if(elemento.Count() > 1) printer.Oficina = elemento[1]; //Cargo la oficina almacenada. Si la tiene cargada el archivo.
                    printer.Estado = Printer.NO_ANALIZADA; //Seteo el estado de la Impresora en No Analizada.
                    retorno.Add(printer); //Agrego la Impresora a la Listas de Retorno.
                }
            }
            else
            {
                //Si por alguna extraña razón no encuentro el archivo limpio la variable que lo almacena en el
                //Application Config.
                ClearCurrentFile();
            }

            return retorno;
        }

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
                        writerNewFile.WriteLine(printer.Ip + "\\" + printer.Oficina);
                    }
                }

                //Guardo el archivo como reciente.
                openFile(filePath);

                //Una vez guardado, encripto el archivo.
                _encriptar(filePath);
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
                        writerNewFile.WriteLine(printer.Ip + "\\" + printer.Oficina);
                    }
                }
                _encriptar(filePath); //Una vez guardado, encripto el archivo.
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
                    string oficina = (string)(range.Cells[row, 5]).Value2; //Leo la columna donde se encuentra la Oficina.
                    if (_isValidIp(ip)) //Valido que la ip sea válida.
                    {
                        printer.Ip = ip; //Cargo la ip a un Objeto Impresora
                        printer.Estado = Printer.NO_ANALIZADA; //Seteo el estado del Objeto Impresora como No Analizada.
                        printer.Oficina = oficina; //Cargo la oficina a un Objeto Impresora.
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
        /// <param name="data"></param>
        public static void exportExcelFile(string filePath, DataTable data, Estadistica estadistica)
        {
            List<Printer> printers = new List<Printer>();

            Application application = new Application();
            //Abro un libro.
            Workbook libros = application.Workbooks.Add();
            //Abro una hoja.
            Worksheet hoja = (Worksheet) libros.Worksheets.Item[1];
            try
            {
                //Recorro todas las filas del DataTable para cargarlas en el List de Printer.
                foreach(DataRow dataRow in data.Rows)
                {
                    Printer printer = new Printer();
                    printer.Modelo = null;
                    printer.Toner = null;
                    printer.UImagen = null;
                    printer.KitMant = null;

                    printer.Ip = dataRow[0].ToString();
                    if(dataRow[1].ToString().Length > 0) printer.Modelo = dataRow[1].ToString();
                    printer.Oficina = dataRow[2].ToString();
                    printer.Estado = dataRow[3].ToString();
                    if (Int32.Parse(dataRow[8].ToString()) >= 0) printer.Toner = Int32.Parse(dataRow[8].ToString());
                    if (Int32.Parse(dataRow[9].ToString()) >= 0) printer.UImagen = Int32.Parse(dataRow[9].ToString());
                    if (Int32.Parse(dataRow[10].ToString()) >= 0) printer.KitMant = Int32.Parse(dataRow[10].ToString());

                    printers.Add(printer);
                }

                //Escribo las Cabeceras de Columnas.
                hoja.Cells[2, 2] = "Ip";
                hoja.Cells[2, 4] = "Modelo";
                hoja.Cells[2, 6] = "Oficina";
                hoja.Cells[2, 12] = "Estado";
                hoja.Cells[2, 13] = "Toner";
                hoja.Cells[2, 14] = "U. Img.";
                hoja.Cells[2, 15] = "Kit. Mant.";

                Range formatRange; //Creo un rango para dar formato a todo.

                //Doy formato a las Cabeceras de Columna y creo su borde externo.
                formatRange = hoja.Range["B2", "O2"];
                formatRange.Font.Bold = true;
                formatRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);
                formatRange.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(114, 159, 206));
                formatRange.Font.Color = ColorTranslator.ToOle(Color.White);

                //Combino las celdas cabeceras que necesitan verse en varias celdas.
                formatRange = hoja.Range["B2", "C2"];
                formatRange.Merge();
                formatRange = hoja.Range["D2", "E2"];
                formatRange.Merge();
                formatRange = hoja.Range["F2", "K2"];
                formatRange.Merge();

                //Escribo cada una de las impresoras dentro de la Lista, comenzando en la Fila 3 ya que la 2 la uso para las Cabeceras.
                int fila = 3;
                foreach(Printer printer in printers)
                {
                    hoja.Cells[fila, 2] = printer.Ip.ToString();
                    if (printer.Modelo!=null) hoja.Cells[fila, 4] = printer.Modelo.ToString();
                    hoja.Cells[fila, 6] = printer.Oficina;
                    hoja.Cells[fila, 12] = printer.Estado.ToString();
                    if (printer.Toner != null) hoja.Cells[fila, 13] = printer.Toner.ToString() + "%";
                    if (printer.UImagen != null) hoja.Cells[fila, 14] = printer.UImagen.ToString() + "%";
                    if (printer.KitMant != null) hoja.Cells[fila, 15] = printer.KitMant.ToString() + "%";

                    //Combio celdas de acuerdo a si combiné su cabecera.
                    formatRange = hoja.Range[hoja.Cells[fila, 2], hoja.Cells[fila, 3]];
                    formatRange.Merge();
                    formatRange = hoja.Range[hoja.Cells[fila, 4], hoja.Cells[fila, 5]];
                    formatRange.Merge();
                    formatRange = hoja.Range[hoja.Cells[fila, 6], hoja.Cells[fila, 11]];
                    formatRange.Merge();

                    //Doy formato a las filas de acuerdo al estado del suministro. Primero me aseguro que la impresora esté Online.
                    if (printer.Estado == "Online")
                    {
                        //Paint the the complete row as required
                        if(printer.Toner<=10 || printer.UImagen<=10 || (printer.KitMant!=null && printer.KitMant <= 10))
                        {
                            formatRange = hoja.Range[hoja.Cells[fila, 2], hoja.Cells[fila, 15]];
                            formatRange.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(255, 252, 204));
                        }
                        if (printer.Toner <= 3 || printer.UImagen <= 3 || (printer.KitMant != null && printer.KitMant <= 3))
                        {
                            formatRange = hoja.Range[hoja.Cells[fila, 2], hoja.Cells[fila, 15]];
                            formatRange.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(251, 207, 208));
                        }
                    }

                    fila++;
                }

                //Creo los bordes externos.
                string rangoFinal = "O" + (printers.Count + 2).ToString();
                formatRange = hoja.Range["B3", rangoFinal];
                formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);

                //Escribo el total.
                hoja.Cells[fila, 2] = "Total:";
                formatRange = hoja.Cells[fila, 2];
                formatRange.Font.Bold = true;
                formatRange.HorizontalAlignment = XlHAlign.xlHAlignRight;
                formatRange.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(114, 159, 206));
                formatRange.Font.Color = ColorTranslator.ToOle(Color.White);
                hoja.Cells[fila, 3] = printers.Count;
                formatRange = hoja.Cells[fila, 3];
                formatRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                //Hago los bordes externos del total.
                formatRange = hoja.Range[hoja.Cells[fila, 2], hoja.Cells[fila, 3]];
                formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);

                fila += 2;

                //Escribo las Cabeceras de Columnas de Estadisticas.
                hoja.Cells[fila, 2] = "Estados";
                hoja.Cells[fila, 3] = "Cant.";
                hoja.Cells[fila, 4] = "Porc.";
                hoja.Cells[fila, 5] = "Sum Riesgo";
                hoja.Cells[fila, 6] = "Cant.";
                hoja.Cells[fila, 7] = "Porc.";
                hoja.Cells[fila, 8] = "Sum Crítico";
                hoja.Cells[fila, 9] = "Cant.";
                hoja.Cells[fila, 10] = "Porc.";

                //Doy formato a las Cabeceras de Columna y creo su borde externo.
                formatRange = hoja.Range[hoja.Cells[fila, 2], hoja.Cells[fila, 10]];
                formatRange.Font.Bold = true;
                formatRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                formatRange.BorderAround2(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);
                formatRange.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(114, 159, 206));
                formatRange.Font.Color = ColorTranslator.ToOle(Color.White);

                fila++;
                //Cargo las estadísticas
                hoja.Cells[fila, 2] = "Online";
                hoja.Cells[fila, 3] = estadistica.Online.ToString();
                hoja.Cells[fila, 4] = (estadistica.Online * 100 / printers.Count).ToString() + "%";
                hoja.Cells[fila, 5] = "Toner";
                hoja.Cells[fila, 6] = estadistica.TonerRiesgo.ToString();
                hoja.Cells[fila, 7] = (estadistica.TonerRiesgo * 100 / estadistica.Online).ToString() + "%";
                hoja.Cells[fila, 8] = "Toner";
                hoja.Cells[fila, 9] = estadistica.TonerCritico.ToString();
                hoja.Cells[fila, 10] = (estadistica.TonerCritico * 100 / estadistica.Online).ToString() + "%";
                fila++;
                hoja.Cells[fila, 2] = "Offline";
                hoja.Cells[fila, 3] = estadistica.Offline.ToString();
                hoja.Cells[fila, 4] = (estadistica.Offline * 100 / printers.Count).ToString() + "%";
                hoja.Cells[fila, 5] = "U. Img.";
                hoja.Cells[fila, 6] = estadistica.UnImgRiesgo.ToString();
                hoja.Cells[fila, 7] = (estadistica.UnImgRiesgo * 100 / estadistica.Online).ToString() + "%";
                hoja.Cells[fila, 8] = "U. Img.";
                hoja.Cells[fila, 9] = estadistica.UnImgCritico.ToString();
                hoja.Cells[fila, 10] = (estadistica.UnImgCritico * 100 / estadistica.Online).ToString() + "%";
                fila++;
                hoja.Cells[fila, 2] = "No Analiz.";
                hoja.Cells[fila, 3] = estadistica.NoAnalizadas.ToString();
                hoja.Cells[fila, 4] = (estadistica.NoAnalizadas * 100 / printers.Count).ToString() + "%";
                hoja.Cells[fila, 5] = "K. Mant.";
                hoja.Cells[fila, 6] = estadistica.KitMantRiesgo.ToString();
                hoja.Cells[fila, 7] = (estadistica.KitMantRiesgo * 100 / estadistica.Online).ToString() + "%";
                hoja.Cells[fila, 8] = "K. Mant.";
                hoja.Cells[fila, 9] = estadistica.KitMantCritico.ToString();
                hoja.Cells[fila, 10] = (estadistica.KitMantCritico * 100 / estadistica.Online).ToString() + "%";

                //Hago el borde externo
                formatRange = hoja.Range[hoja.Cells[fila - 3, 2], hoja.Cells[fila, 10]];
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

        /// <summary>
        /// Devuelve la última ruta guardada que usó un OpenFileDialog.
        /// </summary>
        /// <returns></returns>
        public static string GetOpenDirectory()
        {
            string path = ConfigurationManager.AppSettings.Get("openDirectory");
            //Compruebo que el directorio exista. Si no, devuelvo C:
            if (!Directory.Exists(path)) path = "c:\\";
            return path;
        }

        /// <summary>
        /// Devuelve la última ruta guardada que usó un SaveFileDialog.
        /// </summary>
        /// <returns></returns>
        public static string GetSaveDirectory()
        {
            string path = ConfigurationManager.AppSettings.Get("saveDirectory");
            //Compruebo que el directorio exista. Si no, devuelvo C:
            if (!Directory.Exists(path)) path = "c:\\";
            return path;
        }

        /// <summary>
        /// Almacena una ruta para usarse en el OpenFileDialog
        /// </summary>
        /// <param name="filePath"></param>
        public static void SetOpenDirectory(string filePath)
        {
            //Me fijo que el File Path no esté vacío. Si lo está, no hago nada.
            if (filePath != String.Empty)
            {
                //Como recibo el path completo, debo quitar de él el nombre del archivo.
                string[] split = filePath.Split('\\');
                bool primero = true;

                for (int i = 0; i < split.Length - 1; i++)
                {
                    if (primero)
                    {
                        filePath = split[i];
                        primero = false;
                    }
                    else
                    {
                        filePath += "\\" + split[i];
                    }
                }

                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                settings["openDirectory"].Value = filePath;

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
        }

        /// <summary>
        /// Almacena una ruta para usarse en el SaveFileDialog
        /// </summary>
        /// <param name="filePath"></param>
        public static void SetSaveDirectory(string filePath)
        {
            //Me fijo que el File Path no esté vacío. Si lo está, no hago nada.
            if (filePath != String.Empty)
            {
                //Como recibo el path completo, debo quitar de él el nombre del archivo.
                string[] split = filePath.Split('\\');
                bool primero = true;

                for (int i = 0; i < split.Length - 1; i++)
                {
                    if (primero)
                    {
                        filePath = split[i];
                        primero = false;
                    }
                    else
                    {
                        filePath += "\\" + split[i];
                    }
                }

                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                settings["saveDirectory"].Value = filePath;

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
        }

        /// <summary>
        /// Toma un archivo de extensión SMP ya creado y lo encripta.
        /// </summary>
        /// <remarks>
        /// Se debe pasar por parámetro la ruta del archivo.
        /// </remarks>
        /// <param name="filePath"></param>
        private static void _encriptar(string filePath)
        {
            string result = String.Empty; //Variable usada para trabajar.

            //Leo el archivo SMP línea por línea.
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line; //Variable para traer la línea leída.
                bool primera = true; //Variable que uso como bandera para saber si estoy leyendo la primer línea.
                while ((line = reader.ReadLine()) != null)
                {
                    if (primera)
                    {
                        //Si es la primera línea, la agrego directamente a la variable result.
                        result = line;
                        primera = false; //Seteo la variable bandera en 'false' porque ya leí la primera línea.
                    }
                    else
                    {
                        //Si no es la primera línea a la variable result le concateno un 'salto de línea' seguido por la 
                        //línea leída.
                        result += '\n' + line;
                    }

                }
            }

            //Encripto la variable result.
            byte[] encrypted = Encoding.Unicode.GetBytes(result);
            result = Convert.ToBase64String(encrypted);

            //Sobreescribo el archivo pasado por parámetro con la cadena (result) ya encriptada.
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(result);
            }
        }

        /// <summary>
        /// Toma un archivo de extensión SMP pasado por parámetro, lo desencripta y devuelve un string.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>
        /// La cadena devuelta ya incluye los saltos de línea. Solo hay que separarlos para armar una Lista o Array.
        /// </returns>
        /// <remarks>
        /// Para separar la cadena devuelta, usar .Split('\n').
        /// </remarks>
        private static string _desencriptar(string filePath)
        {
            string cadena;
            //Leo el archivo pasado por parámetro y cargo lo leído en la variable cadena.
            using (StreamReader reader = new StreamReader(filePath))
            {
                cadena = reader.ReadLine();
            }

            //Desencripto la variable cadena para devolverla como resultado.
            byte[] decryted = Convert.FromBase64String(cadena);
            cadena = Encoding.Unicode.GetString(decryted);

            return cadena;
        }
    }
}
