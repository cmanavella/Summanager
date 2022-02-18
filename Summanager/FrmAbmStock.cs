using CustomExceptions;
using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Summanager
{
    public partial class FrmAbmStock : Form
    {
        //DLLs necesarias para mover el Form.
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public Stock Stock { get; set; }

        public FrmAbmStock() : this(String.Empty) { }

        public FrmAbmStock(string title)
        {
            InitializeComponent();
            this.lblTitulo.Text = title;

            this.Stock = new Stock();

            _ocultarLabelsInfo();
        }

        /// <summary>
        /// Oculta y vacía los Labels de Información.
        /// </summary>
        private void _ocultarLabelsInfo()
        {
            this.lblCodigo.Text = String.Empty;
            this.lblNombre.Text = String.Empty;
            this.lblTipo.Text = String.Empty;
            this.lblCompatible.Text = String.Empty;

            this.label1.Visible = false;
            this.label2.Visible = false;
            this.label3.Visible = false;
            this.label4.Visible = false;
            this.lblCodigo.Visible = false;
            this.lblNombre.Visible = false;
            this.lblTipo.Visible = false;
            this.lblCompatible.Visible = false;
        }

        /// <summary>
        /// Muestra y setea con los valores del parámetro los Labels de Información.
        /// </summary>
        /// <param name="suministro"></param>
        private void _mostrarLabelsInfo(Suministro suministro)
        {
            this.lblCodigo.Text = suministro.Codigo.ToString();
            this.lblNombre.Text = suministro.Nombre;
            this.lblTipo.Text = suministro.Tipo.Nombre;
            this.lblCompatible.Text = String.Empty;

            //Este bucle me arma el string con los modelos compatibles.
            bool primera = true;
            foreach (Modelo modelo in suministro.Modelos)
            {
                if (!primera) this.lblCompatible.Text += ", ";
                this.lblCompatible.Text += modelo.Nombre;
                primera = false;
            }

            this.label1.Visible = true;
            this.label2.Visible = true;
            this.label3.Visible = true;
            this.label4.Visible = true;
            this.lblCodigo.Visible = true;
            this.lblNombre.Visible = true;
            this.lblTipo.Visible = true;
            this.lblCompatible.Visible = true;
        }

        /// <summary>
        /// Busca en la Base de Datos un Suministro por Código.
        /// </summary>
        private void _buscarPorCodigo()
        {
            try
            {
                //Trato de convertir el valor del Text Búsqueda en un Int64.
                Int64 codigo = Convert.ToInt64(this.txtBusqueda.Text);
                //Si no hubo error, busco un suministro por el Código.
                Suministro suministro = DBSuministros.GetSuministro(codigo);

                //Si el suministro no es null, muestro la info del mismo, activo el Text Cantidad y pongo el foco en él.
                if (suministro != null)
                {
                    _mostrarLabelsInfo(suministro);
                    this.txtCantidad.Enabled = true;
                    this.txtCantidad.Focus();
                }
                else
                {
                    //Si es null, lanzo la Exepción de Suministro no Encontrado.
                    throw new SuministroNoEncontradoException();
                }
            }
            catch (FormatException)
            {
                //Si no se puede formatear el contenido del Text Búsqueda, es decir, si este no es numérico, lanzo la Exepción de Suministro no Encontrado.
                throw new SuministroNoEncontradoException();
            }
        }

        /// <summary>
        /// Busca en la Base de Datos un Suministro por Nombre.
        /// </summary>
        private void _buscarPorNombre()
        {
            //Paso el contenido del Text Búsqueda a una variable y busco en la Base de Datos un Suministro con esa información.
            string nombre = this.txtBusqueda.Text;
            List<Suministro> suministros = DBSuministros.GetSuministro(nombre);

            if (suministros != null)
            {
                //Si los Suministros devueltos no son Null me fijo en la cantidad traida.
                if (suministros.Count > 1)
                {
                    //Si la cantidad de suministros es mayor que 1, llamo al Form Choice Element para que se seleccione un suministro.
                    FrmChoiceElement choice = new FrmChoiceElement(suministros);
                    choice.ShowDialog();

                    if (choice.SuministroSeleccionado != null)
                    {
                        //Si el Suministro devuelto no es Null, muestro los Labels de Info y seteo el Text Búsqueda con el Nombre del Suministro.
                        _mostrarLabelsInfo(choice.SuministroSeleccionado);
                        this.txtBusqueda.Text = choice.SuministroSeleccionado.Nombre;
                    }
                    else
                    {
                        //Si es Null, es porque el usuario por alguna razón canceló. Por lo tanto, muestro la Exepción de Suministro no encontrado.
                        throw new SuministroNoEncontradoException();
                    }
                }
                else
                {
                    //Si el Suministro encontrado es uno solo, muestro los Labels de Info con los datos del mismo y seteo el Text Búsqueda con el Nombre
                    //del Suministro.
                    _mostrarLabelsInfo(suministros.First<Suministro>());
                    this.txtBusqueda.Text = suministros.First<Suministro>().Nombre;
                }

                //Activo el Text Cantidad y pongo foco en él.
                this.txtCantidad.Enabled = true;
                this.txtCantidad.Focus();
            }
            else
            {
                //Si los Suministros devueltos de la Base de Datos son Null, lanzo la Excepción de Suministro no Encontrado.
                throw new SuministroNoEncontradoException();
            }
        }

        /// <summary>
        /// Busca en la Base de Datos un Suministro por Nombre de Modelo de Impresora compatible.
        /// </summary>
        private void _buscarPorModelo()
        {
            //Paso el contenido del Text Búsqueda a una variable y busco en la Base de Datos un Suministro con esa información.
            string nombre = this.txtBusqueda.Text;
            List<Suministro> suministros = DBSuministros.GetSuministroByModelo(nombre);

            if (suministros != null)
            {
                //Si los Suministros devueltos no son Null me fijo en la cantidad traida.
                if (suministros.Count > 1)
                {
                    //Si la cantidad de suministros es mayor que 1, llamo al Form Choice Element para que se seleccione un suministro.
                    FrmChoiceElement choice = new FrmChoiceElement(suministros);
                    choice.ShowDialog();

                    if (choice.SuministroSeleccionado != null)
                    {
                        //Si el Suministro devuelto no es Null, muestro los Labels de Info y seteo el Text Búsqueda con el Nombre del Suministro.
                        _mostrarLabelsInfo(choice.SuministroSeleccionado);
                        this.txtBusqueda.Text = choice.SuministroSeleccionado.Nombre;
                    }
                    else
                    {
                        //Si es Null, es porque el usuario por alguna razón canceló. Por lo tanto, muestro la Exepción de Suministro no encontrado.
                        throw new SuministroNoEncontradoException();
                    }
                }
                else
                {
                    //Si el Suministro encontrado es uno solo, muestro los Labels de Info con los datos del mismo y seteo el Text Búsqueda con el Nombre
                    //del Suministro.
                    _mostrarLabelsInfo(suministros.First<Suministro>());
                    this.txtBusqueda.Text = suministros.First<Suministro>().Nombre;
                }

                //Activo el Text Cantidad y pongo foco en él.
                this.txtCantidad.Enabled = true;
                this.txtCantidad.Focus();
            }
            else
            {
                //Si los Suministros devueltos de la Base de Datos son Null, lanzo la Excepción de Suministro no Encontrado.
                throw new SuministroNoEncontradoException();
            }
        }

        /* EVENTOS */
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            btnCancelar_Click(null, null);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea Cancelar la operación?", Application.ProductName + " " + Application.ProductVersion,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                this.Stock = null;
                this.Close();
            }
        }

        private void txtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            //Pregunto si el KeyEventArgs no es Null.
            if(e != null)
            {
                //Oculto los Labels Info.
                _ocultarLabelsInfo();

                //Me aseguro que no se haya presionado la conbinación SHIFT + TAB. De esa manera impido que se ejecute el buscador al querer volver al 
                //control con esa combinación de teclas.
                if(!(e.Shift && e.KeyCode == Keys.Tab))
                {
                    //Me aseguro que la tecla presionada sea ENTER o TAB y que el Text Búsqueda no esté vacío para ejecutar la búsqueda.
                    if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) && this.txtBusqueda.Text.Length > 0)
                    {
                        try
                        {
                            //Intento buscar por Código.
                            _buscarPorCodigo();
                        }
                        catch (SuministroNoEncontradoException)
                        {
                            try
                            {
                                //Si no encuentra un Suministro por Código, intento por Nombre.
                                _buscarPorNombre();
                            }
                            catch (SuministroNoEncontradoException)
                            {
                                try
                                {
                                    //Si no encuentra Suministro por Nombre, intento por Modelo de Impresora Compatible
                                    _buscarPorModelo();
                                }
                                catch (SuministroNoEncontradoException ex)
                                {
                                    //En este punto no hay un Suministro con el criterio de búsqueda especificado.
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            //Si hubo alguna otra Excepción en el camino, la muestro.
                            MessageBox.Show(ex.Message, Application.ProductName + " " + Application.ProductVersion,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    //Si no se cumple la condición anterior y el Text Búsqueda permanece vacío. Muestro mensaje y pongo Foco en el mismo.
                    else if (this.txtBusqueda.Text.Length == 0)
                    {
                        MessageBox.Show("El campo de búsqueda no debe estar vacío", Application.ProductName + " " + Application.ProductVersion,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.txtBusqueda.Focus();
                    }
                }
            }
        }

        private void txtBusqueda_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //Hago esto para impedir que el Text Búsqueda pierda el foco al presionar la tecla TAB.
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
            }
        }

        private void FrmAbmStock_Shown(object sender, EventArgs e)
        {
            //Pongo el foco en el Botón Cerrar cuando muestro el Formulario ya que si no lo hago el que toma el foco es el Text Búsqueda y no muestra
            //el MaskaredText
            this.btnCerrar.Focus();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Esto lo hago para que solo se puedan escribir números en el TextBox Cantidad.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
