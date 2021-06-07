using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using IO;

namespace Summanager
{
    public partial class frmMain : Form
    {
        private List<string> ips;
        public frmMain()
        {
            InitializeComponent();
            this.ips = File.readIpFile();
        }

        private string _fechaHora()
        {
            DateTime time = DateTime.Now;

            return time.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btnAnalizar_Clic(object sender, MouseEventArgs e)
        {
            txtConsola.Clear();
            txtConsola.AppendText("[" + _fechaHora() + "] INICIO NUEVO ANÁLISIS.");
            txtConsola.AppendText(Environment.NewLine);
            foreach (string ip in this.ips)
            {
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
        }
    }
}
