using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

        //DLLs needed for Form Moving.
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //DLL for Form Border Rouded.
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public frmMain()
        {
            InitializeComponent();
            ips = IO.File.readCurrentFile();
            cantProces = 0;
            porcProces = 0;
            logFile = IO.File.openLogFile();
            printers = new List<Printer>();
            _tituloForm();

            t = new Thread(new ThreadStart(_analizar));
            t.IsBackground = true;

            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text {
            get 
            {
                return base.Text; 
            }
            set
            {
                lblTitulo.Text = value; 
                base.Text = value;
            }
        }

        /// <summary>
        /// Change the Form Title.
        /// </summary>
        private void _tituloForm()
        {
            string fileName = ips[0];
            ips.RemoveAt(0);
            fileName = fileName.Substring(1, fileName.Length - 2) + ".smp";
            string[] titulo = Text.Split('-');

            Text = titulo[0] + "-" + fileName;
        }

        /// <summary>
        /// Return the Current File Title.
        /// </summary>
        /// <returns></returns>
        private string _getCurrentTitle()
        {
            string[] splitTitle = Text.Split('-');
            return splitTitle[1].Substring(0, splitTitle[1].Length - 4);
        }

        /// <summary>
        /// Gets the actual Datetime for its future use.
        /// </summary>
        /// <returns></returns>
        private static string _fechaHora()
        {
            DateTime time = DateTime.Now;

            return time.ToString("dd/MM/yyyy HH:mm:ss");
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

            foreach(var printer in printers)
            {
                string toner = "";
                string uimagen = "";
                string kitmant = "";

                if (printer.Toner != null) toner = printer.Toner + "%";
                if (printer.UImagen != null) uimagen = printer.UImagen + "%";
                if (printer.KitMant != null) kitmant = printer.KitMant + "%";

                dgv.Invoke(new MethodInvoker(() => { dgv.Rows.Add(printer.Ip, printer.Modelo, 
                    printer.Estado, toner, uimagen, kitmant); }));
            }
            _colorearDgv();
        }

        /// <summary>
        /// Color the DataGridView Row according to the Printer Information
        /// </summary>
        private void _colorearDgv()
        {
            foreach(DataGridViewRow r in dgv.Rows)
            {
                if((string)r.Cells[2].Value == Printer.ONLINE)
                {
                    int toner = Int32.Parse(r.Cells[3].Value.ToString().Remove(r.Cells[3].Value.ToString().Length - 1));
                    int uimagen = Int32.Parse(r.Cells[4].Value.ToString().Remove(r.Cells[4].Value.ToString().Length - 1));
                    int kmant = -1;
                    if ((string)r.Cells[1].Value != Printer.L410_TITLE)
                    {
                        kmant = Int32.Parse(r.Cells[5].Value.ToString().Remove(r.Cells[5].Value.ToString().Length - 1));
                    }

                    if(toner<=10 || uimagen<=10 || (kmant>=0 && kmant<=10))
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

            string msjeLog= "[" + _fechaHora() + "] INICIO NUEVO ANÁLISIS.";
            txtConsola.Invoke(new MethodInvoker(() => { txtConsola.AppendText(msjeLog); }));
            txtConsola.Invoke(new MethodInvoker(() => { txtConsola.AppendText(Environment.NewLine); }));
            logFile.WriteLine(msjeLog);

            cantProces = 0;
            porcProces = 0;

            foreach (string ip in ips)
            {
                cantProces++;
                porcProces = cantProces * 100 / ips.Count;
                progressBar1.Invoke(new MethodInvoker(() => { progressBar1.Value = porcProces; }));

                WebScraping webScrap = new WebScraping();

                msjeLog = "[" + _fechaHora() + "] Analizando Ip '" + ip + "'...";
                txtConsola.Invoke(new MethodInvoker(() => { txtConsola.AppendText(msjeLog); }));
                txtConsola.Invoke(new MethodInvoker(() => { txtConsola.AppendText(Environment.NewLine); }));
                logFile.WriteLine(msjeLog);
                try
                {
                    Printer printer = webScrap.readIp(ip);
                    msjeLog = "[" + _fechaHora() + "] Impresora Online: " + printer.Modelo + " Toner: " +
                        printer.Toner + "% - Unidad de Imagen: " + printer.UImagen + "%";
                    if (printer.KitMant != null) msjeLog += " - Kit de Mantenimiento: " + printer.KitMant + " % ";
                    txtConsola.Invoke(new MethodInvoker(() => { txtConsola.AppendText(msjeLog); }));
                    txtConsola.Invoke(new MethodInvoker(() => { txtConsola.AppendText(Environment.NewLine); }));
                    logFile.WriteLine(msjeLog);
                    printer.Ip = ip;
                    printer.Estado = "Online";
                    printers.Add(printer);
                }
                catch (Exception ex)
                {
                    msjeLog = "[" + _fechaHora() + "] Impresora Offline: " + ex.Message;
                    txtConsola.Invoke(new MethodInvoker(() => { txtConsola.AppendText(msjeLog); }));
                    txtConsola.Invoke(new MethodInvoker(() => { txtConsola.AppendText(Environment.NewLine); }));
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
            txtConsola.Invoke(new MethodInvoker(() => { txtConsola.AppendText(msjeLog); }));
            txtConsola.Invoke(new MethodInvoker(() => { txtConsola.AppendText(Environment.NewLine); }));
            logFile.WriteLine(msjeLog);
            progressBar1.Invoke(new MethodInvoker(() => { progressBar1.Value = 0; }));
            _llenarDgv();

            btnAbrir.Invoke(new MethodInvoker(() => { btnAbrir.Enabled = true; }));
            btnGuardar.Invoke(new MethodInvoker(() => { btnGuardar.Enabled = true; }));
            btnActualizar.Invoke(new MethodInvoker(() => { btnActualizar.Enabled = true; }));
            btnDetener.Invoke(new MethodInvoker(() => { btnDetener.Enabled = false; }));
            btnImportar.Invoke(new MethodInvoker(() => { btnImportar.Enabled = true; }));
            btnExportar.Invoke(new MethodInvoker(() => { btnExportar.Enabled = true; }));
            t.Abort();
        }

        /// <summary>
        /// Call the Method wich analize all List of IPs in other thread.
        /// </summary>
        private void _threadAnalizar()
        {
            btnAbrir.Enabled = false;
            btnGuardar.Enabled = false;
            btnActualizar.Enabled = false;
            btnDetener.Enabled = true;
            btnImportar.Enabled = false;
            btnExportar.Enabled = false;

            if (!t.IsAlive)
            {
                t = new Thread(new ThreadStart(_analizar));
                t.IsBackground = true;
            }
            t.Start();
        }

        /**EVENTS**/
        private void btnAnalizar_Clic(object sender, MouseEventArgs e)
        {
            _threadAnalizar();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _threadAnalizar();
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            t.Abort();
            string msjeLog = "[" + _fechaHora() + "] ANÁLISIS FINALIZADO POR EL USUARIO.";
            txtConsola.AppendText(msjeLog);
            txtConsola.AppendText(Environment.NewLine);
            logFile.WriteLine(msjeLog);
            progressBar1.Value = 0;
            _llenarDgv();
            btnAbrir.Enabled = true;
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = true;
            btnDetener.Enabled = false;
            btnImportar.Enabled = true;
            btnExportar.Enabled = true;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            IO.File.closeLogFile(logFile);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
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
                    string msjeLog = "[" + _fechaHora() + "] Guardando archivo...";
                    txtConsola.AppendText(msjeLog);
                    txtConsola.AppendText(Environment.NewLine);
                    logFile.WriteLine(msjeLog);

                    IO.File.saveFile(filePath, ips);

                    msjeLog = "[" + _fechaHora() + "] Archivo guardado con éxito.";
                    txtConsola.AppendText(msjeLog);
                    txtConsola.AppendText(Environment.NewLine);
                    logFile.WriteLine(msjeLog);

                    ips.Clear();
                    ips = IO.File.readCurrentFile();
                    _tituloForm();
                } catch (Exception ex)
                {
                    string msjeLog = "[" + _fechaHora() + "] Error al guardar archivo: " +
                        ex.Message;
                    txtConsola.AppendText(msjeLog);
                    txtConsola.AppendText(Environment.NewLine);
                    logFile.WriteLine(msjeLog);
                }
            }
            saveFileDialog.FileName = "";
        }

        private void btnAbrir_Click(object sender, EventArgs e)
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
                    string msjeLog = "[" + _fechaHora() + "] Abriendo archivo...";
                    txtConsola.AppendText(msjeLog);
                    txtConsola.AppendText(Environment.NewLine);
                    logFile.WriteLine(msjeLog);


                    IO.File.openFile(filePath);

                    msjeLog = "[" + _fechaHora() + "] Archivo abierto con éxito.";
                    txtConsola.AppendText(msjeLog);
                    txtConsola.AppendText(Environment.NewLine);
                    logFile.WriteLine(msjeLog);

                    ips.Clear();
                    ips = IO.File.readCurrentFile();
                    _tituloForm();
                    _threadAnalizar();
                }
                catch (Exception ex)
                {
                    string msjeLog = "[" + _fechaHora() + "] Error al abrir archivo: " +
                        ex.Message;
                    txtConsola.AppendText(msjeLog);
                    txtConsola.AppendText(Environment.NewLine);
                    logFile.WriteLine(msjeLog);
                }
            }
            openFileDialog.FileName = "";
        }

        private void btnExportar_Click(object sender, EventArgs e)
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
                    string msjeLog = "[" + _fechaHora() + "] Exportando archivo...";
                    txtConsola.AppendText(msjeLog);
                    txtConsola.AppendText(Environment.NewLine);
                    logFile.WriteLine(msjeLog);

                    IO.File.exportExcelFile(filePath, printers);

                    msjeLog = "[" + _fechaHora() + "] Archivo exportado con éxito.";
                    txtConsola.AppendText(msjeLog);
                    txtConsola.AppendText(Environment.NewLine);
                    logFile.WriteLine(msjeLog);
                }
                catch(Exception ex)
                {
                    string msjeLog = "[" + _fechaHora() + "] Error al abrir archivo: " +
                        ex.Message;
                    txtConsola.AppendText(msjeLog);
                    txtConsola.AppendText(Environment.NewLine);
                    logFile.WriteLine(msjeLog);
                }
            }
            saveFileDialog.FileName = "";
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string estado = dgv.SelectedCells[2].Value.ToString();
            string ip = "http://" + dgv.SelectedCells[0].Value.ToString();
            if(estado=="Online") Process.Start(ip);
        }

        private void btnImportar_Click(object sender, EventArgs e)
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
                    string msjeLog = "[" + _fechaHora() + "] Importando archivo...";
                    txtConsola.AppendText(msjeLog);
                    txtConsola.AppendText(Environment.NewLine);
                    logFile.WriteLine(msjeLog);

                    newIps = IO.File.importExcelFile(filePath);

                    msjeLog = "[" + _fechaHora() + "] Archivo Importado con éxito.";
                    txtConsola.AppendText(msjeLog);
                    txtConsola.AppendText(Environment.NewLine);
                    logFile.WriteLine(msjeLog);
                }
                catch(Exception ex)
                {
                    string msjeLog = "[" + _fechaHora() + "] Error al abrir archivo: " +
                        ex.Message;
                    txtConsola.AppendText(msjeLog);
                    txtConsola.AppendText(Environment.NewLine);
                    logFile.WriteLine(msjeLog);
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

        private void btnCerrar_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void lblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
