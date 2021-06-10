using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        //private delegate void SafeDgvRefreshDelegate();

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
        }

        private void _tituloForm()
        {
            string fileName = ips[0];
            ips.RemoveAt(0);
            fileName = fileName.Substring(1, fileName.Length - 2) + ".smp";
            string[] titulo = Text.Split('-');

            Text = titulo[0] + "-" + fileName;
        }

        private static string _fechaHora()
        {
            DateTime time = DateTime.Now;

            return time.ToString("dd/MM/yyyy HH:mm:ss");
        }

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

        private void _colorearDgv()
        {
            foreach(DataGridViewRow r in dgv.Rows)
            {
                if((string)r.Cells[2].Value == "Online")
                {
                    int toner = Int32.Parse(r.Cells[3].Value.ToString().Remove(r.Cells[3].Value.ToString().Length - 1));
                    int uimagen = Int32.Parse(r.Cells[4].Value.ToString().Remove(r.Cells[4].Value.ToString().Length - 1));
                    int kmant = -1;
                    if ((string)r.Cells[1].Value != "Lexmark MS410dn")
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

        //private void dgvRefresh()
        //{
        //    if (dgv.InvokeRequired)
        //    {
        //        var d = new SafeDgvRefreshDelegate();
        //        dgv.Invoke(new SafeDgvRefreshDelegate, dgv.Refresh());
        //    }
        //}

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

        private void btnAnalizar_Clic(object sender, MouseEventArgs e)
        {
            _threadAnalizar();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //CheckForIllegalCrossThreadCalls = false;
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
                    saveFileDialog.FileName = "";
                } catch (Exception ex)
                {
                    string msjeLog = "[" + _fechaHora() + "] Error al guardar archivo: " +
                        ex.Message;
                    txtConsola.AppendText(msjeLog);
                    txtConsola.AppendText(Environment.NewLine);
                    logFile.WriteLine(msjeLog);
                }
            }
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
                    saveFileDialog.FileName = "";
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
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string estado = dgv.SelectedCells[2].Value.ToString();
            string ip = "http://" + dgv.SelectedCells[0].Value.ToString();
            if(estado=="Online") Process.Start(ip);
        }
    }
}
