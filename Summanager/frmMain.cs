using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using IO;

namespace Summanager
{
    public partial class frmMain : Form
    {
        private static List<string> ips;
        private List<Printer> printers;
        private static int cantProces;
        private static int porcProces;
        private Thread t;
        private static StreamWriter logFile;

        public frmMain()
        {
            InitializeComponent();
            ips = IO.File.readIpFile();
            cantProces = 0;
            porcProces = 0;
            logFile = IO.File.openLogFile();
            printers = new List<Printer>();
        }

        private static string _fechaHora()
        {
            DateTime time = DateTime.Now;

            return time.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void _analizar()
        {
            if (printers.Count > 0) printers.Clear();

            string msjeLog= "[" + _fechaHora() + "] INICIO NUEVO ANÁLISIS.";
            txtConsola.AppendText(msjeLog);
            txtConsola.AppendText(Environment.NewLine);
            logFile.WriteLine(msjeLog);

            cantProces = 0;
            porcProces = 0;

            foreach (string ip in ips)
            {
                cantProces++;
                porcProces = cantProces * 100 / ips.Count;
                progressBar1.Value = porcProces;

                WebScraping webScrap = new WebScraping();

                msjeLog = "[" + _fechaHora() + "] Analizando Ip '" + ip + "'...";
                txtConsola.AppendText(msjeLog);
                txtConsola.AppendText(Environment.NewLine);
                logFile.WriteLine(msjeLog);
                try
                {
                    Printer printer = webScrap.readIp(ip);
                    msjeLog = "[" + _fechaHora() + "] Impresora Online: " + printer.Modelo + " Toner: " +
                        printer.Toner + "% - Unidad de Imagen: " + printer.UImagen + "%";
                    if (printer.KitMant != null) msjeLog += " - Kit de Mantenimiento: " + printer.KitMant + " % ";
                    txtConsola.AppendText(msjeLog);
                    txtConsola.AppendText(Environment.NewLine);
                    logFile.WriteLine(msjeLog);
                    printer.Ip = ip;
                    printer.Estado = "Online";
                    printers.Add(printer);
                }
                catch (Exception ex)
                {
                    msjeLog = "[" + _fechaHora() + "] Impresora Offline: " + ex.Message;
                    txtConsola.AppendText(msjeLog);
                    txtConsola.AppendText(Environment.NewLine);
                    logFile.WriteLine(msjeLog);
                    Printer printer = new Printer();
                    printer.Ip = ip;
                    printer.Estado = "Offline";
                    printer.Modelo = null;
                    printer.Toner = null;
                    printer.UImagen = null;
                    printer.KitMant = null;
                    printers.Add(printer);
                }
            }

            msjeLog = "[" + _fechaHora() + "] ANÁLISIS FINALIZADO.";
            txtConsola.AppendText(msjeLog);
            txtConsola.AppendText(Environment.NewLine);
            logFile.WriteLine(msjeLog);
            progressBar1.Value = 0;
        }

        private void btnAnalizar_Clic(object sender, MouseEventArgs e)
        {
            t = new Thread(_analizar);
            t.Start();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            t.Abort();
            string msjeLog = "[" + _fechaHora() + "] ANÁLISIS FINALIZADO POR EL USUARIO.";
            txtConsola.AppendText(msjeLog);
            txtConsola.AppendText(Environment.NewLine);
            logFile.WriteLine(msjeLog);
            progressBar1.Value = 0;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            IO.File.closeLogFile(logFile);
        }
    }
}
