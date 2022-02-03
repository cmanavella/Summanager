using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Summanager
{
    public partial class FrmActualizarChromeDriver : Summanager.FrmEmergente
    {
        public FrmActualizarChromeDriver()
        {
            InitializeComponent();
        }

        private void FrmActualizarChromeDriver_Shown(object sender, EventArgs e)
        {
            //Si el BackGround Worker no está ocupado lo pongo a funcionar.
            if (!worker.IsBusy) worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var version = GetChromeVersion();
                var urlToDownload = GetURLToDownload(version);
                KillAllChromeDriverProcesses();
                DownloadChromeDriver(urlToDownload);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName + " " + Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Obtiene la versión de Google Chrome instalada en el sistema.
        /// </summary>
        /// <returns></returns>
        private string GetChromeVersion()
        {     
            //Ingreso a la Variable de Registro donde se encuentra almacenada la versión de Google Chrome.
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\chrome.exe"))
            {
                if (key != null)
                {
                    Object o = key.GetValue("");
                    if (!String.IsNullOrEmpty(o.ToString()))
                    {
                        string productVersionPath = o.ToString(); //Obtengo la ruta de la versión.

                        //Me aseguro de que esa ruta exista.
                        if (!File.Exists(productVersionPath))
                        {
                            throw new FileNotFoundException("No se puede obtener la versión de Google Chrome debido a que" +
                                " la ruta especificada apunta a un archivo que no existe. Comuníquese con su Administrador.");
                        }

                        //Obtengo y devuelvo la versión de Google Chrome.
                        var versionInfo = FileVersionInfo.GetVersionInfo(productVersionPath);
                        if (versionInfo != null && !String.IsNullOrEmpty(versionInfo.FileVersion))
                        {
                            return versionInfo.FileVersion;
                        }
                        else
                        {
                            throw new ArgumentException("No se puede obtener la versión de Google Chrome debido a que la misma es nula o se encuentra vacía: " + 
                                productVersionPath + ". Comuníquese con su Administrador.");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("No se puede obtener la versión de Google Chrome debido a que la Variable de " +
                            "Registro se encuentra vacía. Comuníquese con su Administrador.");
                    }
                }
                else
                {
                    throw new ArgumentException("No se puede obtener la versión de Google Chrome debido a que la Variable de " +
                        "Registro se encuentra vacía. Comuníquese con su Administrador.");
                }
            }
        }

        /// <summary>
        /// Obtiene la URL de donde se va a descargar el ChromeDriver.
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        private string GetURLToDownload(string version)
        {
            //Me aseguro que el número de versión de Google Chrome no se encuentre vacía.
            if (String.IsNullOrEmpty(version))
            {
                throw new ArgumentException("No se puede obtener la versión de Google Chrome debido a que la misma se encuentra vacía. " +
                    "Comuníquese con su Administrador.");
            }

            //Obtengo la versión de ChromeDriver ingresando a una URL, con el último número de la versión de Google Chrome.
            string html = string.Empty;
            string urlToPathLocation = @"https://chromedriver.storage.googleapis.com/LATEST_RELEASE_" + String.Join(".", version.Split('.').First());

            //Preparo la compresión del archivo en ZIP.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlToPathLocation);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            //Leo la versión de ChromeDriver.
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            //Me aseguro que la versión de ChromeDriver no sea nula.
            if (String.IsNullOrEmpty(html))
            {
                throw new WebException("No se puede obtener la versión de Chromedriver desde la URL especificada. Comuníquese con su Administrador.");
            }

            //Devuelvo la URL de descarga del ChromeDriver.
            return "https://chromedriver.storage.googleapis.com/" + html + "/chromedriver_win32.zip";
        }

        /// <summary>
        /// Detiene todos los procesos de ChromeDriver abiertos en el Sistema Operativo.
        /// </summary>
        private void KillAllChromeDriverProcesses()
        {
            //Obtengo los procesos.
            var processes = Process.GetProcessesByName("chromedriver");
            //Los recorro uno a uno y los detengo si se puede, sino muestro una exepxión.
            foreach (var process in processes)
            {
                try
                {
                    process.Kill();
                }
                catch
                {
                    throw new Exception("No se puede detener el proceso 'chromedriver'.");
                }
            }
        }

        /// <summary>
        /// Descarga el ChromeDriver de la ruta especificada.
        /// </summary>
        /// <param name="urlToDownload"></param>
        private void DownloadChromeDriver(string urlToDownload)
        {
            //Me aseguro que la URL de descarga no sea nula o no esté vacía.
            if (String.IsNullOrEmpty(urlToDownload))
            {
                throw new ArgumentException("No se puede descargar Chromedriver debido a que la ruta de descarga es nula o se encuentra vacía. " +
                    "Comuníquese con su Administrador.");
            }

            using (var client = new WebClient())
            {
                //Me aseguro de que no haya otra descarga realizada en el directorio de la App. Si la hay, la elimino.
                if (File.Exists(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\chromedriver.zip"))
                {
                    File.Delete(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\chromedriver.zip");
                }

                //Descargo el archivo ZIP con el nuevo ChromeDriver.
                client.DownloadFile(urlToDownload, "chromedriver.zip");

                //Me aseguro de que el archivo ZIP se haya descargado y que si a la vez hay un chromedriver instalado en el directorio se lo elimine.
                if (File.Exists(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\chromedriver.zip") && File.Exists(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\chromedriver.exe"))
                {
                    File.Delete(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\chromedriver.exe");
                }

                if (File.Exists(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\chromedriver.zip"))
                {
                    ZipFile.ExtractToDirectory(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\chromedriver.zip", Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
                }
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Cuando el BGW termina, cierro el Form.
            this.Close();
        }
    }
}
