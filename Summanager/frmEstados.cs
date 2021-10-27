using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using IO;

namespace Summanager
{
    public partial class FrmEstados : Summanager.FrmContenido
    {
        private List<Printer> printers;
        private FrmMain frmMain;
        private Estadistica estadisticaGral;
        private Estadistica estadisticaPart;
        private bool automatizo;
        private Int64 periodo;
        private Int64 contador;
        private bool estGrales;


        public FrmEstados(FrmMain frmMain)
        {
            InitializeComponent();
            
            this.frmMain = frmMain;
            this.printers = new List<Printer>();
            this.automatizo = File.getActualizacionEstados();
            this.periodo = Periodo.GetPeriodo(File.getPeriodo());
            this.contador = 0;

            this.estadisticaGral = new Estadistica();
            this.estadisticaPart = new Estadistica();
            this.estGrales = true;

            _cargarCombos();
        }

        /// <summary>
        /// Devuelve la última ruta guardada que usó un OpenFileDialog.
        /// </summary>
        /// <returns></returns>
        private string _getOpenDirectory()
        {
            string retorno = String.Empty;
            string openDirectory = IO.File.GetOpenDirectory();
            //Me fijo que el OpenDirectory no esté vacío
            if (openDirectory != String.Empty)
            {
                retorno = openDirectory; //Seteo el Initial Directory del OpenFileDialog.
            }
            else
            {
                //Si el OpenDirectory está vacío, seteo en C:
                retorno = "c:\\";
            }
            return retorno;
        }

        /// <summary>
        /// Devuelve la última ruta guardada que usó un SaveFileDialog.
        /// </summary>
        /// <returns></returns>
        private string _getSaveDirectory()
        {
            string retorno = String.Empty;
            string saveDirectory = IO.File.GetSaveDirectory();
            //Me fijo que el SaveDirectory no esté vacío
            if (saveDirectory != String.Empty)
            {
                retorno = saveDirectory; //Seteo el Initial Directory del SaveFileDialog.
            }
            else
            {
                //Si el SaveDirectory está vacío, seteo en C:
                retorno = "c:\\";
            }
            return retorno;
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
        /// Devuelve si el archivo abierto es nuevo.
        /// </summary>
        /// <returns></returns>
        private bool _esNuevo()
        {
            return _getFileTitle() == "sin título";
        }

        private void _cargarCombos()
        {
            //Cargo el Combo Estados
            this.cmbEstados.Add(0, "-- Seleccione --");
            this.cmbEstados.Add(1, "Online");
            this.cmbEstados.Add(2, "Offline");
            this.cmbEstados.Add(3, "No Analizada");

            //Cargo el Combo Suministros.
            this.cmbSuministro.Add(0, "-- Seleccione --");
            this.cmbSuministro.Add(1, "En Riesgo");
            this.cmbSuministro.Add(2, "Crítico");
        }

        /// <summary>
        /// Permite filtrar el DataGridView
        /// </summary>
        private void _filtrar()
        {
            //Armo el StringBuilder de filtro vacío.
            StringBuilder filtro = new StringBuilder();

            //Pregunto si el texto no está mascarado y si tiene algo escrito.
            if (!this.txtFiltro.IsMaskared && this.txtFiltro.Text.Length > 0)
            {
                //Si se cumple la condición armo el filtro, analizando la columna que armé con las tres columnas que quiero analizar con el textbox.
                //Uso LIKE para que filtre con cualquier coincidencia.
                filtro.Append("[FiltroTextBox] LIKE '%" + this.txtFiltro.Text + "%'");
            }
            //Evaluo si el ComboEstados tiene un valor mayor a 0. Eso significa que elegí un elemento.
            if (this.cmbEstados.SelectedItem().Value > 0)
            {
                //Pregunto si el filtro ya tiene contenido. Si lo tiene agrego AND para que se filtre solo si se cumplen las condiciones anteriores.
                if (filtro.Length > 0) filtro.Append("AND");
                filtro.Append("[Estado] = '" + this.cmbEstados.SelectedItem().Text + "'");
            }
            //Evaluo si el ComboSuministros tiene un valor mayor a 0 para saber si hay un elemento seleccionado.
            if (this.cmbSuministro.SelectedItem().Value > 0)
            {
                //Me fijo en su valor. Si es 1 debo hacer un filtro para los Suministros en riesgo. Si es 2 lo debo hacer para los Críticos.
                if (this.cmbSuministro.SelectedItem().Value == 1)
                {
                    //Pregunto si el filtro ya tiene contenido. Si lo tiene agrego AND para que se filtre solo si se cumplen las condiciones anteriores.
                    if (filtro.Length > 0) filtro.Append("AND");
                    //Compruebo que cada una de las columnas numéricas se encuentren en rango de riesgo que es entre 3 y 10.
                    filtro.Append("(([FiltroToner] > 3 AND [FiltroToner] <= 10) OR ");
                    filtro.Append("([FiltroUI] > 3 AND [FiltroUI] <= 10) OR ");
                    filtro.Append("([FiltroKM] > 3 AND [FiltroKM] <= 10))");
                }
                else
                {
                    //Pregunto si el filtro ya tiene contenido. Si lo tiene agrego AND para que se filtre solo si se cumplen las condiciones anteriores.
                    if (filtro.Length > 0) filtro.Append("AND");
                    //Compruebo que cada una de las columnas numéricas se encuentren en rango crítico que es entre 0 y 3.
                    filtro.Append("(([FiltroToner] >= 0 AND [FiltroToner] <= 3) OR ");
                    filtro.Append("([FiltroUI] >= 0 AND [FiltroUI] <= 3) OR ");
                    filtro.Append("([FiltroKM] >= 0 AND [FiltroKM] <= 3))");
                }
            }

            //Analizo si el filtro no está vacío. Si no lo está, filtro. Si se encuentra vacío borro el filtro en el DGV.
            if (filtro.Length > 0)
            {
                (this.dgv.DataSource as DataTable).DefaultView.RowFilter = filtro.ToString();
                _getEstadisticaParticular(); //Calculo las Estadísticas Particulares al filtro.

                //Muestro el Botón de Cambiar Estadísticas.
                this.btnCambiarEst.Visible = true;
                //Cambio la variable bandera de EstGrales a False para marcar que efectivamente estoy mostrando las Estadísticas Particulares.
                this.estGrales = false;
                //Cambio el texto del Group Estadísticas.
                this.groupEstadisticas.Text = "Estadísticas Particulares";
            }
            else if (this.dgv.DataSource as DataTable != null)
            {
                (this.dgv.DataSource as DataTable).DefaultView.RowFilter = null;
                _showEstadistica(this.dgv.Rows.Count, true); //Como las Estadísticas Generales ya las calculé, las muestro.
                
                //Oculto el botón de Cambiar Estadísticas.
                this.btnCambiarEst.Visible = false;
                //Cambio la variable bandera de EstGrales a True para marcar que efectivamente estoy mostrando las Estadísticas Generales.
                this.estGrales = true;
                //Cambio el texto del Group Estadísticas.
                this.groupEstadisticas.Text = "Estadísticas Generales";
            }

            //Cambio el valor del LblTotal.
            this.lblTotal.Text = "Total: " + this.dgv.Rows.Count;
        }

        /// <summary>
        /// Acomoda los botones del Form Estados de acuerdo a si es un nuevo archivo (fijándome en el Título del
        /// Form Main) o si la Lista de Impresoras está vacía.
        /// </summary>
        private void _acomodarBotones()
        {
            if(_esNuevo())
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
        /// Crea un nuevo DataTable a partir de los valores mostrados en un DataGridView.
        /// </summary>
        /// <remarks>
        /// A diferencia del DataSource del DataGridView este método usa los valores visibles en la misma. Sirve para cuando se ha
        /// aplicado un Filtro.
        /// </remarks>
        /// <returns></returns>
        private DataTable _getFilterData()
        {
            DataTable data = new DataTable();

            //Cargo los encabezados de las Columnas con sus respectivos nombres y textos a mostrar.
            data.Columns.Add("Ip", typeof(string));
            data.Columns.Add("Modelo", typeof(string));
            data.Columns.Add("Oficina", typeof(string));
            data.Columns.Add("Estado", typeof(string));
            data.Columns.Add("Toner", typeof(string));
            data.Columns.Add("UI", typeof(string));
            data.Columns.Add("KM", typeof(string));
            data.Columns.Add("FiltroTextBox", typeof(string));
            data.Columns.Add("FiltroToner", typeof(int));
            data.Columns.Add("FiltroUI", typeof(int));
            data.Columns.Add("FiltroKM", typeof(int));

            //Recorro cada fila del DGV.
            foreach (DataGridViewRow fila in this.dgv.Rows)
            {
                //Almaceno cada valor de cada celda en una variable.
                string ip = fila.Cells["Ip"].Value.ToString();
                string modelo = fila.Cells["Modelo"].Value.ToString();
                string oficina = fila.Cells["Oficina"].Value.ToString();
                string estado = fila.Cells["Estado"].Value.ToString();
                string toner = fila.Cells["Toner"].Value.ToString();
                string ui = fila.Cells["UI"].Value.ToString();
                string km = fila.Cells["KM"].Value.ToString();
                string filtroTextBox = fila.Cells["FiltroTextBox"].Value.ToString();
                int filtroToner = Int32.Parse(fila.Cells["FiltroToner"].Value.ToString());
                int filtroUI = Int32.Parse(fila.Cells["FiltroUI"].Value.ToString());
                int filtroKM = Int32.Parse(fila.Cells["FiltroKM"].Value.ToString());

                //Cargo las variables en el DataTable que devuelvo.
                data.Rows.Add(ip, modelo, oficina, estado, toner, ui, km, filtroTextBox, filtroToner, filtroUI, filtroKM);
            }

            return data;
        }

        /// <summary>
        /// Carga el DataGridView con una Lista de Impresoras y colorea las filas de acuerdo al Estado de las mismas.
        /// </summary>
        private void _llenarDgv()
        {
            //Ordeno la Lista de Impresoras por la Oficina.
            this.printers.Sort((x, y) => x.Oficina.CompareTo(y.Oficina));

            //Compruebo que la Lista de Impresoras no esté vacía.
            if (printers.Count > 0)
            {
                DataTable dataTable = new DataTable();

                //Cargo los encabezados de las Columnas con sus respectivos nombres y textos a mostrar.
                dataTable.Columns.Add("Ip", typeof(string));
                dataTable.Columns.Add("Modelo", typeof(string));
                dataTable.Columns.Add("Oficina", typeof(string));
                dataTable.Columns.Add("Estado", typeof(string));
                dataTable.Columns.Add("Toner", typeof(string));
                dataTable.Columns.Add("UI", typeof(string));
                dataTable.Columns.Add("KM", typeof(string));
                //Creo una columna especial con un string que contiene todos los valores de las columnas que quiero filtrar con el TextBox.
                dataTable.Columns.Add("FiltroTextBox", typeof(string));
                //Creo una columna oculta por cada suministro para filtrar luego.
                dataTable.Columns.Add("FiltroToner", typeof(int));
                dataTable.Columns.Add("FiltroUI", typeof(int));
                dataTable.Columns.Add("FiltroKM", typeof(int));

                //Recorro la Lista de Impresoras para cargarlas.
                foreach (var printer in printers)
                {
                    //Creo las variables toner, uimagen y kitmant como strings vacíos para, en caso de que estos 
                    //suministros sean nulos, no mostrar nada.
                    string toner = "";
                    string uimagen = "";
                    string kitmant = "";

                    //Creo las variables numericas de los suministros para agregarlas a su respectiva columna usada para filtrarlos.
                    //Las seteo a todas en -1.
                    int filtroToner = -1;
                    int filtroUI = -1;
                    int filtroKM = -1;

                    //Compruebo que los suministros no sean nulos. Si no lo son, concateno el valor del suministro seguido
                    //por el signo '%' y coloco su valor en su respectiva variable numérica.
                    if (printer.Toner != null) 
                    {
                        toner = printer.Toner + "%";
                        filtroToner = (int)printer.Toner;
                    }
                    if (printer.UImagen != null)
                    { 
                        uimagen = printer.UImagen + "%";
                        filtroUI = (int)printer.UImagen;
                    }
                    if (printer.KitMant != null) 
                    { 
                        kitmant = printer.KitMant + "%";
                        filtroKM = (int)printer.KitMant;
                    }

                    //Uso StringBuilder para armar la cadena de filtro para el TextBox.
                    StringBuilder filtroTextBox = new StringBuilder();
                    filtroTextBox.Append(printer.Ip);
                    filtroTextBox.Append("\t");
                    filtroTextBox.Append(printer.Modelo);
                    filtroTextBox.Append("\t");
                    filtroTextBox.Append(printer.Oficina);

                    //Agrego una nueva fila.
                    dataTable.Rows.Add(printer.Ip, printer.Modelo, printer.Oficina, printer.Estado, toner, uimagen, kitmant, filtroTextBox,
                        filtroToner, filtroUI, filtroKM);
                }

                this.dgv.DataSource = dataTable;

                //Oculto las columnas filtros
                this.dgv.Columns["FiltroTextBox"].Visible = false;
                this.dgv.Columns["FiltroToner"].Visible = false;
                this.dgv.Columns["FiltroUI"].Visible = false;
                this.dgv.Columns["FiltroKM"].Visible = false;

                //Desactivo la Opción de Ordenar las Columnas al hacer clic en su encabezado.
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                //Modifico el tamaño de algunas Columnas.
                dgv.Columns[1].Width = 150;
                dgv.Columns[2].Width = 525;
                dgv.Columns[4].Width = 50;
                dgv.Columns[5].Width = 50;
                dgv.Columns[6].Width = 50;
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
                if ((string)r.Cells[3].Value == Printer.ONLINE)
                {
                    //Cargo los suministros en variables para su mejor manejo.
                    int toner = Int32.Parse(r.Cells[4].Value.ToString().Remove(r.Cells[4].Value.ToString().Length - 1));
                    int uimagen = Int32.Parse(r.Cells[5].Value.ToString().Remove(r.Cells[5].Value.ToString().Length - 1));
                    int kmant = -1; //Ya que como no es un suministro que tengan todos los modelos, primero lo seteo en -1.
                    
                    //Consulto si la Impresora analizada no es una Lexmark MS410.
                    if ((string)r.Cells[1].Value != Printer.L410_TITLE)
                    {
                        //Si no lo es, cargo el valor del Kit de Mantenimiento.
                        kmant = Int32.Parse(r.Cells[6].Value.ToString().Remove(r.Cells[6].Value.ToString().Length - 1));
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

            //Muestro los elementos del Filtro.
            this.lblTotal.Text = "Total: " + this.printers.Count;
            this.lblTotal.Visible = true;
            this.txtFiltro.Visible = true;
            this.lblEstado.Visible = true;
            this.cmbEstados.Visible = true;
            this.lblSuministro.Visible = true;
            this.cmbSuministro.Visible = true;
            //this.btnAgregar.Visible = true;
            //this.btnQuitar.Visible = true;
            this.btnLimpiar.Visible = true;
        }

        /// <summary>
        /// Muestra la Estadísticas y las modifica.
        /// </summary>
        /// <param name="total"></param>
        /// <param name="esGral"></param>
        private void _showEstadistica(int total, bool esGral)
        {
            groupEstadisticas.Visible = true;

            //Primero cargo las cantidades en base a si es la Estadística general o no.
            Estadistica estadistica;
            if (esGral)
            {
                estadistica = this.estadisticaGral;
            }
            else
            {
                estadistica = this.estadisticaPart;
            }
            this.estOnline.Count = estadistica.Online;
            this.estOffline.Count = estadistica.Offline;
            this.estNoAna.Count = estadistica.NoAnalizadas;
            this.estTonerRiesgo.Count = estadistica.TonerRiesgo;
            this.estUnImgRiesgo.Count = estadistica.UnImgRiesgo;
            this.estKitMantRiesgo.Count = estadistica.KitMantRiesgo;
            this.estTonerCritico.Count = estadistica.TonerCritico;
            this.estUnImgCritico.Count = estadistica.UnImgCritico;
            this.estKitMantCritico.Count = estadistica.KitMantCritico;

            //Cargo los totales.
            this.estOnline.Total = total;
            this.estOffline.Total = total;
            this.estNoAna.Total = total;
            this.estTonerRiesgo.Total = estadistica.Online;
            this.estUnImgRiesgo.Total = estadistica.Online;
            this.estKitMantRiesgo.Total = estadistica.Online;
            this.estTonerCritico.Total = estadistica.Online;
            this.estUnImgCritico.Total = estadistica.Online;
            this.estKitMantCritico.Total = estadistica.Online;
        }

        private void _getEstadisticaParticular()
        {
            //Limpio todas las Estadísticas.
            this.estadisticaPart.NoAnalizadas = 0;
            this.estadisticaPart.Online = 0;
            this.estadisticaPart.Offline = 0;
            this.estadisticaPart.TonerRiesgo = 0;
            this.estadisticaPart.UnImgRiesgo = 0;
            this.estadisticaPart.KitMantRiesgo = 0;
            this.estadisticaPart.TonerCritico = 0;
            this.estadisticaPart.UnImgCritico = 0;
            this.estadisticaPart.KitMantCritico = 0;

            //Cargo el total y lo paso a las Impresoras No Analizadas.
            int total = this.dgv.Rows.Count;
            if (total > 0)
            {
                this.estadisticaPart.NoAnalizadas = total;

                //Si analizo, acomodo los datos para la estadisticaPart.
                foreach(DataGridViewRow fila in this.dgv.Rows)
                {
                    int toner = Int32.Parse(fila.Cells["FiltroToner"].Value.ToString());
                    int UI = Int32.Parse(fila.Cells["FiltroUI"].Value.ToString());
                    int KM = Int32.Parse(fila.Cells["FiltroKM"].Value.ToString());

                    if (fila.Cells["Estado"].Value.ToString() != Printer.NO_ANALIZADA)
                    {
                        this.estadisticaPart.NoAnalizadas--; //Quito una del contador de No Analizadas.
                        if (fila.Cells["Estado"].Value.ToString() == Printer.ONLINE)
                        {
                            this.estadisticaPart.Online++;
                        }
                        else
                        {
                            this.estadisticaPart.Offline++;
                        }
                    }

                    //Hago la Estadística de los Suministros.
                    //Primero con lo de riesgo.
                    if (toner <= 10 && toner > 3) this.estadisticaPart.TonerRiesgo++;
                    if (UI <= 10 && UI > 3) this.estadisticaPart.UnImgRiesgo++;
                    if (KM <= 10 && KM > 3) this.estadisticaPart.KitMantRiesgo++;

                    //Sigo con los críticos
                    if (toner >= 0 && toner <= 3) this.estadisticaPart.TonerCritico++;
                    if (UI >= 0 && UI <= 3) this.estadisticaPart.UnImgCritico++;
                    if (KM >= 0 && KM <= 3) this.estadisticaPart.KitMantCritico++;
                }
            }
            //Muestro las estadísticas.
            _showEstadistica(total, false);
        }

        /// <summary>
        /// Calcula la Estadística General. Es decir, del total de datos procesados.
        /// </summary>
        private void _getEstadisticaGral()
        {
            if (this.dgv.DataSource != null)
            {
                DataTable tabla = (DataTable)this.dgv.DataSource;
                if (tabla.Rows.Count > 0)
                {
                    //Limpio todas las Estadísticas.
                    this.estadisticaGral.NoAnalizadas = 0;
                    this.estadisticaGral.Online = 0;
                    this.estadisticaGral.Offline = 0;
                    this.estadisticaGral.TonerRiesgo = 0;
                    this.estadisticaGral.UnImgRiesgo = 0;
                    this.estadisticaGral.KitMantRiesgo = 0;
                    this.estadisticaGral.TonerCritico = 0;
                    this.estadisticaGral.UnImgCritico = 0;
                    this.estadisticaGral.KitMantCritico = 0;

                    //Cargo el total y lo paso a las Impresoras No Analizadas.
                    int total = tabla.Rows.Count;
                    this.estadisticaGral.NoAnalizadas = total;

                    //Si analizo, acomodo los datos para la estadisticaGral.
                    for (int i = 0; i < tabla.Rows.Count; i++)
                    {
                        int toner = Int32.Parse(tabla.Rows[i]["FiltroToner"].ToString());
                        int UI = Int32.Parse(tabla.Rows[i]["FiltroUI"].ToString());
                        int KM = Int32.Parse(tabla.Rows[i]["FiltroKM"].ToString());

                        if (tabla.Rows[i]["Estado"].ToString() != Printer.NO_ANALIZADA)
                        {
                            this.estadisticaGral.NoAnalizadas--; //Quito una del contador de No Analizadas.
                            if (tabla.Rows[i]["Estado"].ToString() == Printer.ONLINE)
                            {
                                this.estadisticaGral.Online++;
                            }
                            else
                            {
                                this.estadisticaGral.Offline++;
                            }
                        }

                        //Hago la Estadística de los Suministros.
                        //Primero con lo de riesgo.
                        if (toner <= 10 && toner > 3) this.estadisticaGral.TonerRiesgo++;
                        if (UI <= 10 && UI > 3) this.estadisticaGral.UnImgRiesgo++;
                        if (KM <= 10 && KM > 3) this.estadisticaGral.KitMantRiesgo++;

                        //Sigo con los críticos
                        if (toner >= 0 && toner <= 3) this.estadisticaGral.TonerCritico++;
                        if (UI >= 0 && UI <= 3) this.estadisticaGral.UnImgCritico++;
                        if (KM >= 0 && KM <= 3) this.estadisticaGral.KitMantCritico++;
                    }

                    //Muestro las estadísticas.
                    _showEstadistica(total, true);
                }
            }
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
            openFileDialog.InitialDirectory = _getOpenDirectory();
            openFileDialog.Filter = "Libro de Excel (*.xlsx;*.xls)|*.xlsx;*.xls";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            //Si abre un archivo y no cancela importo los datos.
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName; //Cargo la ruta y el nombre del archivo con el OFD.

                //Instancio el Form Importando que es el que se encarga de importar el archivo Excel elegido, y lo
                //muestro como Dialog.
                FrmImportando frmImportando = new FrmImportando(filePath);
                frmImportando.ShowDialog();

                //Pregunto si no hubo error.
                if (!frmImportando.Error)
                {
                    //Si no lo hubo continuo con el desarrollo del código.

                    //Pregunto si se desea combinar la Lista de Impresoras con lo Importado.
                    if (combinado)
                    {
                        //Creo una Lista de Impresoras nueva y la cargo con los datos del archivo Excel.
                        List<Printer> nuevas = frmImportando.Printers;

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
                        this.printers.Clear();
                        this.printers = frmImportando.Printers;
                    }
                    MessageBox.Show("Datos importados con éxito."); //Muestro mensaje de éxito.
                }else
                {
                    //Si hubo algún error muestro el mensaje.
                    MessageBox.Show(frmImportando.Exception.Message);
                }
            }

            IO.File.SetOpenDirectory(openFileDialog.FileName); //Guardo el último directorio.
            openFileDialog.FileName = ""; //Limpio el OFD.

            //Pregunto si la Lista de Impresoras no está vacia.
            if (printers.Count > 0)
            {
                _tituloForm(); //Actualizo el Título del Form Main.
                //A ese título le concateno al final el caracter '*' que es mi bandera para saber si un archivo ha sido modificado.
                frmMain.Text += "*";
                btnActualizar_Click(null, null); //Analizo la Lista de Impresoras.
                _acomodarBotones(); //Acomodo los botones.
            }
        }

        /// <summary>
        /// Guarda un archivo con un Nombre Específico en una Ruta deseada con extensión 'SMP'.
        /// </summary>
        /// <returns></returns>
        private DialogResult _saveAs()
        {
            DialogResult retorno; //Variable de retorno.

            //Abro y seteo el SaveFileDialog.
            saveFileDialog.InitialDirectory = _getSaveDirectory();
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

            IO.File.SetSaveDirectory(this.saveFileDialog.FileName); //Guardo el último directorio.
            saveFileDialog.FileName = ""; //Limpio el SaveFileDialog.

            return retorno; //Devuelvo el resultado.
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
                string estado = dgv.SelectedCells[3].Value.ToString(); //Obtengo el Estado de la Impresora.
                string ip = "http://" + dgv.SelectedCells[0].Value.ToString(); //Concateno 'http://' con el Ip de la Impresora.
                //Abro la página HTTP de la Impresora si esta se encuentra Online o no ha sido analizada.
                if (estado == Printer.ONLINE || estado == Printer.NO_ANALIZADA) Process.Start(ip);
            }
        }

        private void frmEstados_Load(object sender, EventArgs e)
        {
            try
            {
                printers = IO.File.readCurrentFile();
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede acceder al archivo.", Application.ProductName + ": Archivo dañado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnNuevo_Click(null, null);
            }

            _tituloForm();
            _acomodarBotones();

            if(!_esNuevo()) btnActualizar_Click(sender, null); //Actualizo el DGV con el análisis de la Lista de Impresoras.
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //Chequeo que el archivo esté guardado. Si lo está, puedo crear un nuevo archivo.
            if (this.frmMain.CheckUnsavedFile() == DialogResult.OK)
            {

                this.printers.Clear(); //Limpio la Lista de Impresoras.
                                       //Limpio el DGV.
                this.dgv.Columns.Clear();
                this.dgv.Refresh();
                groupEstadisticas.Visible = false;

                //Limpio la variable de Application Config que almacena la ruta del archivo reciente.
                IO.File.ClearCurrentFile();
                _tituloForm(); //Actualizo el Título del Form Main.
                _acomodarBotones(); //Acomodo los botones.
                this.lblTotal.Visible = false;
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            //Seteo el OpenFileDialog.
            openFileDialog.InitialDirectory = _getOpenDirectory();
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
                    btnActualizar_Click(sender, null); //Analizo la Lista de Impresoras.
                }
                catch (Exception ex)
                {
                    //Filtro para mostrar el error del Archivo Roto.
                    if (ex.GetType().Name == "FormatException")
                    {
                        MessageBox.Show("No se puede acceder al archivo.", Application.ProductName + ": Archivo dañado",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message); //Si huibo un error, lo muestro.
                    }
                    btnNuevo_Click(null, null);
                }
            }

            IO.File.SetOpenDirectory(openFileDialog.FileName); //Guardo el último directorio.
            openFileDialog.FileName = ""; //Limpio el OFD.
            _acomodarBotones(); //Acomodo los botones.
        }

        private void btnGuardar_Click(object sender, EventArgs e)
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

        private void btnGuardarComo_Click(object sender, EventArgs e)
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

        private void btnImportar_Click(object sender, EventArgs e)
        {
            //Primero pregunto que el archivo es nuevo.
            if (!_esNuevo())
            {
                //Si no lo es, pregunto si con la importación de Excel se desea combinar los datos obtenidos con los 
                //del archivo.
                var result = MessageBox.Show("¿Desea combinar la colección en el archivo actual con los datos importados? \n\nSi elige la opción " +
                    "\"Sí\" se combinará la colección actual con los datos importados. Si elige " +
                    "la opción \"No\" se borrará la colección actual y se generá una nueva a partir de los datos importado.",
                    Application.ProductName, MessageBoxButtons.YesNoCancel);

                //Si no se cancela el llamado, llamo al método Importar, pasándole como parámetro la decisión tomada.
                if (result != DialogResult.Cancel) _importar(result == DialogResult.Yes);
            }
            else
            {
                //Si el archivo es nuevo llamo al método Importar pasándole por parámetro que se desea combinar.
                _importar(true);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            //Exporta una Lista de Impresoras a un archivo de Excel. 

            //Creo el Form Exportando, el cual se va a encargar de hacer la exportación a Excel.
            FrmExportando frmExportando;

            //Seteo el SaveFileDialog.
            saveFileDialog.InitialDirectory = _getSaveDirectory();
            saveFileDialog.Filter = "Libro de Excel (*.xlsx)|*.xlsx";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            //Creo la variable que contiene el Path para almacenar el Excel, vacía
            string filePath = String.Empty; 
            //La visibilidad del Botón Cambiar (entre estadísticas Generales y Particulares) me indica si se ha aplicado un filtro o no.
            //Si es visible se ha aplicado un filtro, sino no.
            if (this.btnCambiarEst.Visible)
            {
                var result = MessageBox.Show("¿Desea exportar solamente el resultado del Filtro Aplicado? \n\nSi elige la opción " +
                    "\"Sí\" se exportarán solamente las Impresoras en pantalla. Si elige " +
                    "la opción \"No\" se exportarán Todas las Impresoras Analizadas.",
                    Application.ProductName, MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes) //Pregunto si decide exportar lo fitrado o no.
                {
                    //Pregunto si no ha cancelado.
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = saveFileDialog.FileName; //Almaceno la ruta y el nombre del archivo Excel a exportar.
                        //Exporto el archivo Excel con los datos del Filtro.
                        frmExportando = new FrmExportando(filePath, _getFilterData(), this.estadisticaPart); //Instancio el Form Exportando con los param requeridos.
                        frmExportando.ShowDialog(); //Lo muestro como Dialog.

                        //Pregunto si hubo error y muestro el mensaje según la situación.
                        if (frmExportando.Error)
                        {
                            MessageBox.Show(frmExportando.Exception.Message);
                        }
                        else
                        {
                            MessageBox.Show("Datos exportados con éxito."); //Muestro mensaje de éxito.
                        }
                    }
                }
                else
                {
                    //Pregunto si no ha cancelado.
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = saveFileDialog.FileName; //Almaceno la ruta y el nombre del archivo Excel a exportar.
                        //Exporto el archivo Excel con los datos Generales.
                        frmExportando = new FrmExportando(filePath, (DataTable)this.dgv.DataSource, this.estadisticaGral); //Instancio el Form Exportando con los param requeridos.
                        frmExportando.ShowDialog();//Lo muestro como Dialog.

                        //Pregunto si hubo error y muestro el mensaje según la situación.
                        if (frmExportando.Error)
                        {
                            MessageBox.Show(frmExportando.Exception.Message);
                        }
                        else
                        {
                            MessageBox.Show("Datos exportados con éxito."); //Muestro mensaje de éxito.
                        }
                    }
                }
            }
            else
            {
                //Pregunto si no ha cancelado.
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog.FileName; //Almaceno la ruta y el nombre del archivo Excel a exportar.
                    //Exporto el archivo Excel.
                    frmExportando = new FrmExportando(filePath, (DataTable)this.dgv.DataSource, this.estadisticaGral); //Instancio el Form Exportando con los param requeridos.
                    frmExportando.ShowDialog();//Lo muestro como Dialog.

                    //Pregunto si hubo error y muestro el mensaje según la situación.
                    if (frmExportando.Error)
                    {
                        MessageBox.Show(frmExportando.Exception.Message);
                    }
                    else
                    {
                        MessageBox.Show("Datos exportados con éxito."); //Muestro mensaje de éxito.
                    }
                }
            }

            IO.File.SetSaveDirectory(this.saveFileDialog.FileName); //Guardo el último directorio.
            saveFileDialog.FileName = ""; //Limpio el SFD.
            _acomodarBotones(); //Acomodo botones.
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Si automatizo, apago el Timer Contador antes de actualizar. De esa manera trato de que no haya problemas
            if (automatizo) this.timerContador.Enabled = false;
            //Oculto la etiqueta la última actualización.
            this.lblActualizacion.Visible = false;

            //Limpio el DGV.
            this.dgv.DataSource = null;
            this.dgv.Refresh();

            //Oculto elementos
            this.lblTotal.Visible = false;
            this.txtFiltro.Visible = false;
            this.lblEstado.Visible = false;
            this.cmbEstados.Visible = false;
            this.lblSuministro.Visible = false;
            this.cmbSuministro.Visible = false;
            this.btnLimpiar.Visible = false;
            this.btnAgregar.Visible = false;
            groupEstadisticas.Visible = false;

            //Llamo al Form Cargando para que analice la Lista de Impresoras pasadas por parámetros.
            FrmCargando cargando = new FrmCargando(printers);
            cargando.ShowDialog(); //Lo muestro como un dialog para que mientras analiza no se pueda hacer nada.

            List<Printer> printersReturned = cargando.PrintersPassed; //Cargo una nueva Lista de Impresoras con lo devuelto.

            //Actualizo la Lista de Impresoras actual con la devuelta por el Form Cargando.
            foreach (Printer printer in printersReturned)
            {
                int i = this.printers.FindIndex(o => o.Ip == printer.Ip);
                this.printers[i] = printer;
            }

            _llenarDgv(); //Cargo el DGV con lo analizado.

            //Cargo la fecha y hora de la última actualización.
            this.lblActualizacion.Text = "Última actualización: " + Fecha.ParceFecha(DateTime.Now);
            //Muestro la etiqueta de la última actualización.
            this.lblActualizacion.Visible = true;
            //Hago las Estadísticas Generales.
            _getEstadisticaGral();
            //Filtro el DGV.
            _filtrar();

            //Si automatizo la actualización pongo el contador en 0 y enciendo el Timer.
            if (this.automatizo)
            {
                this.contador = 0;
                this.timerContador.Enabled = true;
            }
        }

        private void FrmEstados_Shown(object sender, EventArgs e)
        {
            
            if (this.printers.Count <= 0)
            {
                groupEstadisticas.Visible = false;
            }
        }

        private void txtFiltro_KeyUp(object sender, KeyEventArgs e)
        {
            _filtrar();
        }

        private void cmbEstados_ItemSelectedChange(object sender, EventArgs e)
        {
            _filtrar();
        }

        private void cmbSuministro_ItemSelectedChange(object sender, EventArgs e)
        {
            _filtrar();
        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            _colorearDgv();
        }

        private void timerContador_Tick(object sender, EventArgs e)
        {
            this.contador++;
            if(contador == this.periodo)
            {
                btnActualizar_Click(null, null);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtFiltro.Clear();
            this.txtFiltro.Focus();
            this.cmbEstados.SelectItem(0, true);
            this.cmbSuministro.SelectItem(0, true);
            this.btnLimpiar.Focus();
        }

        private void btnCambiarEst_Click(object sender, EventArgs e)
        {
            if (this.estGrales)
            {
                this.estGrales = false;
                this.groupEstadisticas.Text = "Estadísticas Particulares";
                _showEstadistica(this.dgv.Rows.Count, false);
            }
            else
            {
                this.estGrales = true;
                this.groupEstadisticas.Text = "Estadísticas Generales";
                DataTable datos = (DataTable)this.dgv.DataSource;
                _showEstadistica(datos.Rows.Count, true);
            }
        }
    }
}
