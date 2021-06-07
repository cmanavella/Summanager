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
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAnalizar_Clic(object sender, MouseEventArgs e)
        {
            WebScraping webScrap = new WebScraping();
            string ip = txtIp.Text;
            txtConsola.AppendText("Analizando Ip '" + ip + "'...");
            txtConsola.AppendText(Environment.NewLine);
            try
            {
                Printer printer = webScrap.readIp(ip);
                string result = printer.Modelo + ": Impresora analizada correctamente. Toner: " +
                    printer.Toner + "% - Unidad de Imagen: " + printer.UImagen + "%";
                if (printer.KitMant != null) result += " - Kit de Mantenimiento: " + printer.KitMant + " % ";
                txtConsola.AppendText(result);
                txtConsola.AppendText(Environment.NewLine);
            }
            catch (Exception ex)
            {
                txtConsola.AppendText("Impresora Offline: " + ex.Message);
                txtConsola.AppendText(Environment.NewLine);
            }
        }
    }
}
