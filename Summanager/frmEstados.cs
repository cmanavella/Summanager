using Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Summanager
{
    public partial class FrmEstados : Summanager.FrmContenido
    {
        private List<Printer> printers;
        private FrmMain frmMain;

        public FrmEstados(FrmMain frmMain)
        {
            InitializeComponent();
            printers = IO.File.readCurrentFile();

            this.frmMain = frmMain;
            _tituloForm();
            _acomodarBotones();
        }

        /// <summary>
        /// Cambia el Título del Form Main agregando al título de la aplicación el título del archivo abierto.
        /// </summary>
        private void _tituloForm()
        {
            //Daivido el título existente en dos, separados por un '-'.
            string[] titulo = frmMain.Text.Split('-');

            //Me fijo que la Lista de Impresoras no esté vacía. Si no lo está significa que ya hay un 
            //archivo abierto y que por ende tiene un nombre.
            if (printers.Count > 0)
            {
                string fileName = IO.File.GetCurrentFileTitle(); //Obtengo la ruta del archivo abierto.
                string[] splitFileName = fileName.Split('\\'); //Lo divido para extraer solo el nombre del archivo.

                //Si el string devuelto tiene contenido anexo el nombre del archivo sin su extensión al Título del 
                //Form Main.
                if (fileName.Length > 0)
                {
                    int index = splitFileName.Length - 1;

                    frmMain.Text = titulo[0] + "-" + splitFileName[index].Substring(0, splitFileName[index].Length - 4);
                }
                else
                {
                    //Si está vacío muestro sin título como si fuera un archivo nuevo.
                    frmMain.Text = titulo[0] + "-sin título";
                }
            }
            else
            {
                //Si la Lista de Impresoras está vacía, significa que no hay archivo abierto, por lo que muestro la leyenda
                //sin título.
                frmMain.Text = titulo[0] + "-sin título";
            }
        }

        /// <summary>
        /// Obtiene el nombre del archivo abierto, desde el Título del Form Main.
        /// </summary>
        /// <returns></returns>
        private string _getFileTitle()
        {
            string[] splitTitle = frmMain.Text.Split('-');
            return splitTitle[1];
        }

        /// <summary>
        /// Acomoda los botones del Form Estados de acuerdo a si es un nuevo archivo (fijándome en el Título del
        /// Form Main) o si la Lista de Impresoras está vacía.
        /// </summary>
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
        /// Carga el DataGridView con una Lista de Impresoras y colorea las filas de acuerdo al Estado de las mismas.
        /// </summary>
        private void _llenarDgv()
        {
            //Compruebo que la Lista de Impresoras no esté vacía.
            if (printers.Count > 0)
            {
                //Cargo los encabezados de las Columnas con sus respectivos nombres y textos a mostrar.
                dgv.Columns.Add("ip", "Ip");
                dgv.Columns.Add("modelo", "Modelo");
                dgv.Columns.Add("estado", "Estado");
                dgv.Columns.Add("toner", "Toner");
                dgv.Columns.Add("uimagen", "U. Img.");
                dgv.Columns.Add("kmant", "Kit Mant.");

                //Desactivo la Opción de Ordenar las Columnas al hacer clic en su encabezado.
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                //Agrando la segunda Columna.
                dgv.Columns[1].Width = 260;

                //Recorro la Lista de Impresoras para cargarlas.
                foreach (var printer in printers)
                {
                    //Creo las variables toner, uimagen y kitmant como strings vacíos para, en caso de que estos 
                    //suministros sean nulos, no mostrar nada.
                    string toner = "";
                    string uimagen = "";
                    string kitmant = "";

                    //Compruebo que los suministros no sean nulos. Si no lo son, concateno el valor del suministro seguido
                    //por el signo '%'
                    if (printer.Toner != null) toner = printer.Toner + "%";
                    if (printer.UImagen != null) uimagen = printer.UImagen + "%";
                    if (printer.KitMant != null) kitmant = printer.KitMant + "%";

                    //Agrego una nueva fila.
                    dgv.Rows.Add(printer.Ip, printer.Modelo, printer.Estado, toner, uimagen, kitmant);
                }
                //Llamo al método que colorea las filas.
                _colorearDgv();
            }
        }

        /// <summary>
        /// Colorea las Filas del DataGridView de acuerdo el estado de sus suministros.
        /// </summary>
        private void _colorearDgv()
        {
            //Recorro el DGV.
            foreach (DataGridViewRow r in dgv.Rows)
            {
                //Consulto el estado de conectividad de la Impresora. Para colorear debe ser Online, ya que si la Impresora
                //está Offline o no ha sido analizada no tiene sentido colorearla.
                if ((string)r.Cells[2].Value == Printer.ONLINE)
                {
                    //Cargo los suministros en variables para su mejor manejo.
                    int toner = Int32.Parse(r.Cells[3].Value.ToString().Remove(r.Cells[3].Value.ToString().Length - 1));
                    int uimagen = Int32.Parse(r.Cells[4].Value.ToString().Remove(r.Cells[4].Value.ToString().Length - 1));
                    int kmant = -1; //Ya que como no es un suministro que tengan todos los modelos, primero lo seteo en -1.
                    
                    //Consulto si la Impresora analizada no es una Lexmark MS410.
                    if ((string)r.Cells[1].Value != Printer.L410_TITLE)
                    {
                        //Si no lo es, cargo el valor del Kit de Mantenimiento.
                        kmant = Int32.Parse(r.Cells[5].Value.ToString().Remove(r.Cells[5].Value.ToString().Length - 1));
                    }

                    //Si los valores de los Estados de los Suministros son menores a 10, pinto la fila de amarillo.
                    if (toner <= 10 || uimagen <= 10 || (kmant >= 0 && kmant <= 10))
                    {
                        r.DefaultCellStyle.BackColor = Color.FromArgb(255,252,204);
                        r.DefaultCellStyle.ForeColor = Color.Black;
                        r.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 250, 153);
                        r.DefaultCellStyle.SelectionForeColor = Color.Black;
                    }
                    //Sin son menores a 3 la pinto en rojo.
                    if (toner <= 3 || uimagen <= 3 || (kmant >= 0 && kmant <= 3))
                    {
                        r.DefaultCellStyle.BackColor = Color.FromArgb(251, 207, 208);
                        r.DefaultCellStyle.ForeColor = Color.Black;
                        r.DefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 161, 164);
                        r.DefaultCellStyle.SelectionForeColor = Color.Black;
                    }
                }
            }
            dgv.Refresh(); //Refresco el DGV para que se apliquen los cambios.
        }

        private void _getEstadisticas()
        {
            groupEstadisticas.Visible = true;
        }

        /// <summary>
        /// Guarda un archivo con un Nombre Específico en una Ruta deseada con extensión 'SMP'.
        /// </summary>
        /// <returns></returns>
        private DialogResult _saveAs()
        {
            DialogResult retorno; //Variable de retorno.

            //Abro y seteo el SaveFileDialog.
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "SumManager File (*.smp)|*.smp";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            //Pregunto si se ha decidido a guardar el archivo.
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Cargo la ruta y el nombre del archivo.
                string filePath = saveFileDialog.FileName;
                
                //Llamo al método que lo crea si no existe y lo guarda.
                IO.File.saveFileAs(filePath, printers);

                printers.Clear(); //Limpio la Lista de Impresoras.
                printers = IO.File.readCurrentFile(); //Leo el archivo guardado y cargo con él la Lista de Impresoras.
                _tituloForm(); //Actualizo el Título del Form Main.
                retorno = DialogResult.OK; //Cargo en la variable de retorno que todo ha salido OK.
            }
            else
            {
                retorno = DialogResult.Cancel; //Cargo en la variable de retorno el resultado de la cancelación.
            }
            saveFileDialog.FileName = ""; //Limpio el SaveFileDialog.

            return retorno; //Devuelvo el resultado.
        }

        /// <summary>
        /// Permite importar a la Lista de Impresoras datos que se obtienen de leer un archivo Excel con un formato específico.
        /// </summary>
        /// <remarks>
        /// Permite elegir si se desea combinar la Lista de Impresoras actual con los datos importados o no.
        /// </remarks>
        /// <param name="combinado"></param>
        private void _importar(bool combinado)
        {
            //Seteo el OpenFileDialog
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Libro de Excel (*.xlsx;*.xls)|*.xlsx;*.xls";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            //Si abre un archivo y no cancela importo los datos.
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName; //Cargo la ruta y el nombre del archivo con el OFD.

                //Hago un try por las dudas que algo suceda en la importación.
                try
                {
                    //Pregunto si se desea combinar la Lista de Impresoras con lo Importado.
                    if (combinado)
                    {
                        //Creo una Lista de Impresoras nueva y la cargo con los datos del archivo Excel.
                        List<Printer> nuevas = IO.File.importExcelFile(filePath);

                        //Recorro la Lista nueva y cargo uno a uno sus elementos en la Lista de Impresoras usada hasta el 
                        //momento.
                        foreach (Printer nueva in nuevas)
                        {
                            this.printers.Add(nueva);
                        }
                    }
                    else
                    {
                        //Si no se desea combinar, limpio la Lista de Impresoras y la cargo con los datos importados.
                        printers.Clear();
                        printers = IO.File.importExcelFile(filePath);
                    }
                    MessageBox.Show("Datos importados con éxito."); //Muestro mensaje de éxito.
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); //Si ocurrió algún error lo muestro.
                }
            }

            openFileDialog.FileName = ""; //Limpio el OFD.

            //Pregunto si la Lista de Impresoras no está vacia.
            if (printers.Count > 0)
            {
                _tituloForm(); //Actualizo el Título del Form Main.
                //A ese título le concateno al final el caracter '*' que es mi bandera para saber si un archivo ha sido modificado.
                frmMain.Text += "*"; 
                btnActualizar_MouseClick(null, null); //Analizo la Lista de Impresoras.
                _acomodarBotones(); //Acomodo los botones.
            }
        }

        /// <summary>
        /// Guarda un archivo ya abierto. Si el archivo es nuevo lo guarda como...
        /// </summary>
        /// <returns></returns>
        public DialogResult Save()
        {
            DialogResult retorno; //Variable de retorno.

            //Obtengo el nombre del archivo del Título del Form Main, para luego tomar desiciones.
            string titulo = _getFileTitle();
            //Si el nombre del archivo es 'sin título', llamo al método de guardar como.
            if(titulo == "sin título*")
            {
                retorno = _saveAs();
            }
            else
            {
                //Sino, significa que debo guardar la Lista de Impresoras en el archivo ya abierto.
                IO.File.saveFile(this.printers);
                printers.Clear(); //Limpio la Lista de Impresoras.
                printers = IO.File.readCurrentFile(); //Leo el archivo guardado.
                _tituloForm(); //Actualizo el Título del Form Main
                retorno = DialogResult.OK; //Cargo el resultado de la acción en la variable de retorno.
            }

            return retorno; //Devuelvo el resultado.
        }

        /*EVENTOS*/
        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Al hacer doble clic sobre una fila del DGV, abro su página HTML.

            //Primero pregunto que haya elementos cargados en el DGV.
            if (this.dgv.Rows.Count > 0)
            {
                string estado = dgv.SelectedCells[2].Value.ToString(); //Obtengo el Estado de la Impresora.
                string ip = "http://" + dgv.SelectedCells[0].Value.ToString(); //Concateno 'http://' con el Ip de la Impresora.
                //Abro la página HTTP de la Impresora si esta se encuentra Online o no ha sido analizada.
                if (estado == Printer.ONLINE || estado == Printer.NO_ANALIZADA) Process.Start(ip);
            }
        }

        private void frmEstados_Load(object sender, EventArgs e)
        {
            btnActualizar_MouseClick(sender, null); //Actualizo el DGV con el análisis de la Lista de Impresoras.
        }

        private void btnNuevo_MouseClick(object sender, MouseEventArgs e)
        {
            //Chequeo que el archivo esté guardado.
            if (this.frmMain.CheckUnsavedFile() == DialogResult.OK)
            {
                //Si lo está, puedo crear un nuevo archivo.
                this.printers.Clear(); //Limpio la Lista de Impresoras.
                //Limpio el DGV.
                this.dgv.Columns.Clear(); 
                this.dgv.Rows.Clear();
                this.dgv.Refresh();

                groupEstadisticas.Visible = false;

                //Limpio la variable de Application Config que almacena la ruta del archivo reciente.
                IO.File.ClearCurrentFile();
                _tituloForm(); //Actualizo el Título del Form Main.
                _acomodarBotones(); //Acomodo los botones.
            }
        }

        private void btnAbrir_MouseClick(object sender, MouseEventArgs e)
		{
            //Seteo el OpenFileDialog.
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "SumManager File (*.smp)|*.smp";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            //Consulto si se abre un archivo.
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Obtengo la ruta y el nombre del archivo que se desea abrir.
                string filePath = openFileDialog.FileName;
                //Uso try por las dudas que algo suceda.
                try
                {
                    IO.File.openFile(filePath); //Cambio la ruta de la variable en el Application Config.

                    printers.Clear(); //Limpio la Lista de Impresoras.
                    printers = IO.File.readCurrentFile(); //Leo el archivo y cargo la Lista de Impresoras con él.
                    _tituloForm(); //Actualizo el Título del Form Main.
                    btnActualizar_MouseClick(sender, null); //Analizo la Lista de Impresoras.
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); //Si huibo un error, lo muestro.
                }
            }
            openFileDialog.FileName = ""; //Limpio el OFD.
            _acomodarBotones(); //Acomodo los botones.
        }

		private void btnGuardar_MouseClick(object sender, MouseEventArgs e)
		{
            //Llamo al Método de Guardar.
            try
            {
                Save();
                _acomodarBotones(); //Acomodo los botones.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); //Si huibo un error, lo muestro.
            }
        }

        private void btnGuardarComo_MouseClick(object sender, MouseEventArgs e)
        {
            //Lamo al Metodo Guardar Como...
            try
            {
                _saveAs();
                _acomodarBotones(); //Acomodo los botones.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); //Si huibo un error, lo muestro.
            }
        }

        private void btnImportar_MouseClick(object sender, MouseEventArgs e)
		{
            //Primero pregunto que el nombre del archivo no sea 'sin título'. Esto quiere decir que no es nuevo.
            if(_getFileTitle() != "sin título")
            {
                //Si no lo es, pregunto si con la importación de Excel se desea combinar los datos obtenidos con los 
                //del archivo.
                var result = MessageBox.Show("¿Desea combinar la colección en el archivo actual con los datos importados? \n\nSi elige la opción " +
                    "\"Sí\" se combinará la colección actual con los datos importados. Si elige " +
                    "la opción \"No\" se borrará la colección actual y se generá una nueva a partir de los datos importado.",
                    Application.ProductName, MessageBoxButtons.YesNoCancel);

                //Si no se cancela el llamado, llamo al método Importar, pasándole como parámetro la decisión tomada.
                if(result!=DialogResult.Cancel) _importar(result == DialogResult.Yes);
            }
            else
            {
                //Si el archivo es nuevo llamo al método Importar pasándole por parámetro que se desea combinar.
                _importar(true);
            }
        }

		private void btnExportar_MouseClick(object sender, MouseEventArgs e)
		{
            //Exporta una Lista de Impresoras a un archivo de Excel. 

            //Seteo el SaveFileDialog.
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "Libro de Excel (*.xlsx)|*.xlsx";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            //Pregunto si se ha decidido a exportar.
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName; //Almaceno la ruta y el nombre del archivo Excel a exportar.
                //Uso try para asegurarme que no suceda nada durante el proceso.
                try
                {
                    //Exporto el archivo Excel.
                    IO.File.exportExcelFile(filePath, printers);
                    MessageBox.Show("Datos exportados con éxito."); //Muestro mensaje de éxito.
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); //Si huibo un error, lo muestro.
                }
            }
            saveFileDialog.FileName = ""; //Limpio el SFD.
            _acomodarBotones(); //Acomodo botones.
        }

		private void btnActualizar_MouseClick(object sender, MouseEventArgs e)
		{
            //Limpio el DGV.
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            dgv.Refresh();

            groupEstadisticas.Visible = false;

            //Llamo al Form Cargando para que analice la Lista de Impresoras pasadas por parámetros.
            FrmCargando cargando = new FrmCargando(printers);
            cargando.ShowDialog(); //Lo muestro como un dialog para que mientras analiza no se pueda hacer nada.

            List<Printer> printersReturned = cargando.PrintersPassed; //Cargo una nueva Lista de Impresoras con lo devuelto.

            //Actualizo la Lista de Impresoras actual con la devuelta por el Form Cargando.
            foreach(Printer printer in printersReturned)
            {
                int i = this.printers.FindIndex(o => o.Ip == printer.Ip);
                this.printers[i] = printer;
            }

            _llenarDgv(); //Cargo el DGV con lo analizado.

            _getEstadisticas();
        }

        private void FrmEstados_Shown(object sender, EventArgs e)
        {
            groupEstadisticas.Visible = false;
        }
    }
}
