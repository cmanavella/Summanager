using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Summanager
{
    public partial class frmEstados : Summanager.frmContenido
    {
        private List<Printer> printers;
        private Form frmMain;

        public frmEstados(Form frmMain)
        {
            InitializeComponent();
            printers = IO.File.readCurrentFile();

            this.frmMain = frmMain;
            _tituloForm();
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
                int index = splitFileName.Length - 1;

                frmMain.Text = titulo[0] + "-" + splitFileName[index].Substring(0, splitFileName[index].Length - 4);
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


        public DialogResult SaveAs()
        {
            DialogResult retorno;

            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "SumManager File (*.smp)|*.smp";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                
                IO.File.saveFile(filePath, printers);

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

        /*EVENTOS*/
        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string estado = dgv.SelectedCells[2].Value.ToString();
            string ip = "http://" + dgv.SelectedCells[0].Value.ToString();
            if (estado == Printer.ONLINE || estado == Printer.NO_ANALIZADA) Process.Start(ip);
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
        }

		private void btnGuardar_MouseClick(object sender, MouseEventArgs e)
		{
            try
            {
                SaveAs();
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
                btnActualizar_MouseClick(sender, null);
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
        }

		private void btnActualizar_MouseClick(object sender, MouseEventArgs e)
		{
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            dgv.Refresh();

            frmCargando cargando = new frmCargando(printers);
            cargando.ShowDialog();

            List<Printer> printersReturned = cargando.PrintersPassed;

            foreach(Printer printer in printersReturned)
            {
                int i = this.printers.FindIndex(o => o.Ip == printer.Ip);
                this.printers[i] = printer;
            }

            _llenarDgv();
        }
	}
}
