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
            string ip = txtIp.Text;
            txtConsola.AppendText("Analizando Ip '" + ip + "'...");
            txtConsola.AppendText(Environment.NewLine);
            Printer printer = WebScraping.readIp(ip);
            txtConsola.AppendText(printer.Modelo + ": Impresora analizada correctamente. Toner: " + printer.Toner + "% - Unidad de Imagen: " + printer.UImagen +
                "% - Kit de Mantenimiento: " + printer.KitMant + "%");
            txtConsola.AppendText(Environment.NewLine);
        }
    }
}
