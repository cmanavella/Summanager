using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Summanager
{
    public partial class FrmEstados : Summanager.FrmContenido
    {
        private List<Printer> printers;
        private Form frmMain;

        public FrmEstados(Form frmMain)
        {
            InitializeComponent();
            printers = IO.File.readCurrentFile();

            this.frmMain = frmMain;
            _tituloForm();
            _acomodarBotones();
        }

        /// <summary>
        /// Change the Form Title.
        /// </summary>
        private void _tituloForm()
        {
            string[] titulo = frmMain.Text.Split('-');
            if (printers.Count > 0)
            {
                string fileName = IO.File.GetCurrentFileTitle();
                string[] splitFileName = fileName.Split('\\');

                if (fileName.Length > 0)
                {
                    int index = splitFileName.Length - 1;

                    frmMain.Text = titulo[0] + "-" + splitFileName[index].Substring(0, splitFileName[index].Length - 4);
                }
                else
                {
                    frmMain.Text = titulo[0] + "-sin título";
                }
            }
            else
            {
                frmMain.Text = titulo[0] + "-sin título";
            }
        }

        /// <summary>
        /// Return the Current File Title.
        /// </summary>
        /// <returns></returns>
        private string _getFileTitle()
        {
            string[] splitTitle = frmMain.Text.Split('-');
            return splitTitle[1];
        }

        private void _acomodarBotones()
        {
            if(_getFileTitle() == "sin título")
            {
                this.btnAbrir.Enabled = true;
                
                if (this.printers.Count > 0)
                {
                    this.btnNuevo.Enabled = true;
                    this.btnGuardar.Enabled = true;
                    this.btnGuardarComo.Enabled = true;
                    this.btnExportar.Enabled = true;
                    this.btnActualizar.Enabled = true;
                }
                else
                {
                    this.btnNuevo.Enabled = false;
                    this.btnGuardar.Enabled = false;
                    this.btnGuardarComo.Enabled = false;
                    this.btnExportar.Enabled = false;
                    this.btnActualizar.Enabled = false;
                }
                this.btnImportar.Enabled = true;
                this.btnExportar.Enabled = false;
            }
            else
            {
                this.btnNuevo.Enabled = true;
                this.btnAbrir.Enabled = true;
                this.btnGuardar.Enabled = true;
                this.btnGuardarComo.Enabled = true;
                this.btnImportar.Enabled = true;
                this.btnExportar.Enabled = true;
                this.btnActualizar.Enabled = true;
            }
        }

        /// <summary>
        /// Load the DataGridView
        /// </summary>
        /// <remarks>
        /// Load the DataGridView with a Collection of Printers and Color the diferents Rows as its need.
        /// </remarks>
        private void _llenarDgv()
        {
            if (printers.Count > 0)
            {
                dgv.Columns.Add("ip", "Ip");
                dgv.Columns.Add("modelo", "Modelo");
                dgv.Columns.Add("estado", "Estado");
                dgv.Columns.Add("toner", "Toner");
                dgv.Columns.Add("uimagen", "U. Img.");
                dgv.Columns.Add("kmant", "Kit Mant.");

                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                dgv.Columns[1].Width = 260;

                foreach (var printer in printers)
                {
                    string toner = "";
                    string uimagen = "";
                    string kitmant = "";

                    if (printer.Toner != null) toner = printer.Toner + "%";
                    if (printer.UImagen != null) uimagen = printer.UImagen + "%";
                    if (printer.KitMant != null) kitmant = printer.KitMant + "%";

                    dgv.Rows.Add(printer.Ip, printer.Modelo, printer.Estado, toner, uimagen, kitmant);
                }
                _colorearDgv();
            }
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
                        r.DefaultCellStyle.BackColor = Color.FromArgb(255,252,204);
                        r.DefaultCellStyle.ForeColor = Color.Black;
                        r.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 250, 153);
                        r.DefaultCellStyle.SelectionForeColor = Color.Black;
                    }
                    if (toner <= 3 || uimagen <= 3 || (kmant >= 0 && kmant <= 3))
                    {
                        r.DefaultCellStyle.BackColor = Color.FromArgb(251, 207, 208);
                        r.DefaultCellStyle.ForeColor = Color.Black;
                        r.DefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 161, 164);
                        r.DefaultCellStyle.SelectionForeColor = Color.Black;
                    }
                }
            }
            dgv.Refresh();
        }


        private DialogResult _saveAs()
        {
            DialogResult retorno;

            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "SumManager File (*.smp)|*.smp";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                
                IO.File.saveFileAs(filePath, printers);

                printers.Clear();
                printers = IO.File.readCurrentFile();
                _tituloForm();
                retorno = DialogResult.OK;
            }
            else
            {
                retorno = DialogResult.Cancel;
            }
            saveFileDialog.FileName = "";

            return retorno;
        }

        public DialogResult Save()
        {
            DialogResult retorno;

            string titulo = _getFileTitle();
            if(titulo == "sin título*")
            {
                retorno = _saveAs();
            }
            else
            {
                IO.File.saveFile(this.printers);
                printers.Clear();
                printers = IO.File.readCurrentFile();
                _tituloForm();
                retorno = DialogResult.OK;
            }

            return retorno;
        }

        /*EVENTOS*/
        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.dgv.Rows.Count > 0)
            {
                string estado = dgv.SelectedCells[2].Value.ToString();
                string ip = "http://" + dgv.SelectedCells[0].Value.ToString();
                if (estado == Printer.ONLINE || estado == Printer.NO_ANALIZADA) Process.Start(ip);
            }
        }

        private void frmEstados_Load(object sender, EventArgs e)
        {
            btnActualizar_MouseClick(sender, null);
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

                    printers.Clear();
                    printers = IO.File.readCurrentFile();
                    _tituloForm();
                    btnActualizar_MouseClick(sender, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            openFileDialog.FileName = "";
            _acomodarBotones();
        }

		private void btnGuardar_MouseClick(object sender, MouseEventArgs e)
		{
            try
            {
                Save();
                _acomodarBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

		private void btnImportar_MouseClick(object sender, MouseEventArgs e)
		{
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Libro de Excel (*.xlsx;*.xls)|*.xlsx;*.xls";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    printers.Clear();
                    printers = IO.File.importExcelFile(filePath);
                    MessageBox.Show("Datos importados con éxito.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            openFileDialog.FileName = "";

            if (printers.Count > 0)
            {
                _tituloForm();
                frmMain.Text += "*";
                btnActualizar_MouseClick(sender, null);
                _acomodarBotones();
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
                    MessageBox.Show("Datos exportados con éxito.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            saveFileDialog.FileName = "";
            _acomodarBotones();
        }

		private void btnActualizar_MouseClick(object sender, MouseEventArgs e)
		{
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            dgv.Refresh();

            FrmCargando cargando = new FrmCargando(printers);
            cargando.ShowDialog();

            List<Printer> printersReturned = cargando.PrintersPassed;

            foreach(Printer printer in printersReturned)
            {
                int i = this.printers.FindIndex(o => o.Ip == printer.Ip);
                this.printers[i] = printer;
            }

            _llenarDgv();
        }

        private void btnNuevo_MouseClick(object sender, MouseEventArgs e)
        {
            this.printers.Clear();
            this.dgv.Columns.Clear();
            this.dgv.Rows.Clear();
            this.dgv.Refresh();
            IO.File.ClearCurrentFile();
            _tituloForm();
            _acomodarBotones();
        }

        private void btnGuardarComo_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                _saveAs();
                _acomodarBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
