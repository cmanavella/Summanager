using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private int contador;
        private static int cantProces;
        private static int porcProces;
        private Thread t;
        public frmMain()
        {
            InitializeComponent();
            ips = File.readIpFile();
            this.contador = 0;
            cantProces = 0;
            porcProces = 0;
        }

        private static string _fechaHora()
        {
            DateTime time = DateTime.Now;

            return time.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private static void _analizar()
        {
            txtConsola.AppendText("[" + _fechaHora() + "] INICIO NUEVO ANÁLISIS.");
            txtConsola.AppendText(Environment.NewLine);

            cantProces = 0;
            porcProces = 0;

            foreach (string ip in ips)
            {
                cantProces++;
                porcProces = cantProces * 100 / ips.Count;
                progressBar1.Value = porcProces;

                WebScraping webScrap = new WebScraping();
                txtConsola.AppendText("[" + _fechaHora() + "] Analizando Ip '" + ip + "'...");
                txtConsola.AppendText(Environment.NewLine);
                try
                {
                    Printer printer = webScrap.readIp(ip);
                    string result = "[" + _fechaHora() + "] Impresora Online: " + printer.Modelo + " Toner: " +
                        printer.Toner + "% - Unidad de Imagen: " + printer.UImagen + "%";
                    if (printer.KitMant != null) result += " - Kit de Mantenimiento: " + printer.KitMant + " % ";
                    txtConsola.AppendText(result);
                    txtConsola.AppendText(Environment.NewLine);
                }
                catch (Exception ex)
                {
                    txtConsola.AppendText("[" + _fechaHora() + "] Impresora Offline: " + ex.Message);
                    txtConsola.AppendText(Environment.NewLine);
                }
            }

            txtConsola.AppendText("[" + _fechaHora() + "] ANÁLISIS FINALIZADO.");
            txtConsola.AppendText(Environment.NewLine);
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
            txtConsola.AppendText("[" + _fechaHora() + "] ANÁLISIS FINALIZADO POR EL USUARIO.");
            txtConsola.AppendText(Environment.NewLine);
            progressBar1.Value = 0;
        }
    }
}
