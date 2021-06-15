using Entities;
using IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Summanager
{
    public partial class frmEstados : Summanager.frmContenido
    {
        private static List<string> ips;
        private List<Printer> printers;
        private Thread t;
        private static StreamWriter logFile;
        private Form frmMain;

        public frmEstados(Form frmMain)
        {
            InitializeComponent();
            ips = IO.File.readCurrentFile();
            printers = new List<Printer>();

            t = new Thread(new ThreadStart(_analizar));
            t.IsBackground = true;

            this.frmMain = frmMain;
            _tituloForm();
        }

        /// <summary>
        /// Change the Form Title.
        /// </summary>
        private void _tituloForm()
        {
            string fileName = ips[0];
            ips.RemoveAt(0);
            fileName = fileName.Substring(1, fileName.Length - 2) + ".smp";
            string[] titulo = frmMain.Text.Split('-');

            frmMain.Text = titulo[0] + "-" + fileName;
        }

        /// <summary>
        /// Return the Current File Title.
        /// </summary>
        /// <returns></returns>
        private string _getCurrentTitle()
        {
            string[] splitTitle = frmMain.Text.Split('-');
            return splitTitle[1].Substring(0, splitTitle[1].Length - 4);
        }

        /// <summary>
        /// Load the DataGridView
        /// </summary>
        /// <remarks>
        /// Load the DataGridView with a Collection of Printers and Color the diferents Rows as its need.
        /// </remarks>
        private void _llenarDgv()
        {
            dgv.Invoke(new MethodInvoker(() => { dgv.Columns.Add("ip", "Ip"); }));
            dgv.Invoke(new MethodInvoker(() => { dgv.Columns.Add("modelo", "Modelo"); }));
            dgv.Invoke(new MethodInvoker(() => { dgv.Columns.Add("estado", "Estado"); }));
            dgv.Invoke(new MethodInvoker(() => { dgv.Columns.Add("toner", "Toner"); }));
            dgv.Invoke(new MethodInvoker(() => { dgv.Columns.Add("uimagen", "U. Img."); }));
            dgv.Invoke(new MethodInvoker(() => { dgv.Columns.Add("kmant", "Kit Mant."); }));

            foreach (var printer in printers)
            {
                string toner = "";
                string uimagen = "";
                string kitmant = "";

                if (printer.Toner != null) toner = printer.Toner + "%";
                if (printer.UImagen != null) uimagen = printer.UImagen + "%";
                if (printer.KitMant != null) kitmant = printer.KitMant + "%";

                dgv.Invoke(new MethodInvoker(() => {
                    dgv.Rows.Add(printer.Ip, printer.Modelo,
                    printer.Estado, toner, uimagen, kitmant);
                }));
            }
            _colorearDgv();
        }

        /// <summary>
        /// Color the DataGridView Row according to the Printer Information
        /// </summary>
        private void _colorearDgv()
        {
            foreach (DataGridViewRow r in dgv.Rows)
            {
                if ((string)r.Cells[2].Value == Printer.ONLINE)
                {
                    int toner = Int32.Parse(r.Cells[3].Value.ToString().Remove(r.Cells[3].Value.ToString().Length - 1));
                    int uimagen = Int32.Parse(r.Cells[4].Value.ToString().Remove(r.Cells[4].Value.ToString().Length - 1));
                    int kmant = -1;
                    if ((string)r.Cells[1].Value != Printer.L410_TITLE)
                    {
                        kmant = Int32.Parse(r.Cells[5].Value.ToString().Remove(r.Cells[5].Value.ToString().Length - 1));
                    }

                    if (toner <= 10 || uimagen <= 10 || (kmant >= 0 && kmant <= 10))
                    {
                        r.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    if (toner <= 3 || uimagen <= 3 || (kmant >= 0 && kmant <= 3))
                    {
                        r.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
            dgv.Invoke(new MethodInvoker(() => { dgv.Refresh(); }));
        }

        /// <summary>
        /// Analize the List of IPs.
        /// </summary>
        /// <remarks>
        /// Analize all the List of IPs, write each move in the Console, move the ProgressBar and finally 
        /// load the DataGridView.
        /// </remarks>
        private void _analizar()
        {
            if (printers.Count > 0) printers.Clear();
            dgv.Invoke(new MethodInvoker(() => { dgv.Rows.Clear(); }));
            dgv.Invoke(new MethodInvoker(() => { dgv.Columns.Clear(); }));
            dgv.Invoke(new MethodInvoker(() => { dgv.Refresh(); }));

            foreach (string ip in ips)
            {
                WebScraping webScrap = new WebScraping();

                try
                {
                    Printer printer = webScrap.readIp(ip);
                    printer.Ip = ip;
                    printer.Estado = "Online";
                    printers.Add(printer);
                }
                catch (Exception ex)
                {
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

            _llenarDgv();
            t.Abort();
        }

        /// <summary>
        /// Call the Method wich analize all List of IPs in other thread.
        /// </summary>
        private void _threadAnalizar()
        {
            if (!t.IsAlive)
            {
                t = new Thread(new ThreadStart(_analizar));
                t.IsBackground = true;
            }
            t.Start();
        }

        /*EVENTOS*/
        private void btnDetener_Click(object sender, EventArgs e)
        {
            t.Abort();
            _llenarDgv();
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string estado = dgv.SelectedCells[2].Value.ToString();
            string ip = "http://" + dgv.SelectedCells[0].Value.ToString();
            if (estado == "Online") Process.Start(ip);
        }

        private void frmEstados_Load(object sender, EventArgs e)
        {
            _threadAnalizar();
        }

		private void btnAbrir_MouseClick(object sender, MouseEventArgs e)
		{
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "SumManager File (*.smp)|*.smp";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    IO.File.openFile(filePath);

                    ips.Clear();
                    ips = IO.File.readCurrentFile();
                    _tituloForm();
                    _threadAnalizar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            openFileDialog.FileName = "";
        }

		private void btnGuardar_MouseClick(object sender, MouseEventArgs e)
		{
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "SumManager File (*.smp)|*.smp";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                try
                {
                    IO.File.saveFile(filePath, ips);

                    ips.Clear();
                    ips = IO.File.readCurrentFile();
                    _tituloForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            saveFileDialog.FileName = "";
        }

		private void btnImportar_MouseClick(object sender, MouseEventArgs e)
		{
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Libro de Excel (*.xlsx;*.xls)|*.xlsx;*.xls";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            List<string> newIps = new List<string>();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    newIps = IO.File.importExcelFile(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            openFileDialog.FileName = "";

            if (newIps.Count > 0)
            {
                string fileTitle = "[" + _getCurrentTitle() + "]";
                IO.File.writeCurrentFile(newIps, fileTitle);
                ips.Clear();
                ips = newIps;
                ips.Insert(0, fileTitle);
                _tituloForm();
                _threadAnalizar();
            }
        }

		private void btnExportar_MouseClick(object sender, MouseEventArgs e)
		{
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "Libro de Excel (*.xlsx)|*.xlsx";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                try
                {
                    IO.File.exportExcelFile(filePath, printers);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            saveFileDialog.FileName = "";
        }

		private void btnActualizar_MouseClick(object sender, MouseEventArgs e)
		{
            _threadAnalizar();
        }
	}
}
