using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Entities;
using IO;
using CustomControls;
using Summanager.Properties;
using System.Reflection;

namespace Summanager
{
    public partial class FrmMain : Form
    {
        private FrmEstados formEstados;
        private int formWidth;

        //DLLs necesarias para mover el Form.
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public FrmMain()
        {
            InitializeComponent();

            this.Text = Application.ProductName;

            //Armo el Footer.
            var assm = Assembly.GetExecutingAssembly();
            var copyrigth = (AssemblyCopyrightAttribute)assm.GetCustomAttribute(typeof(AssemblyCopyrightAttribute));
            this.lblFooter.Text = Application.ProductName + " v" + Application.ProductVersion + " " + copyrigth.Copyright;

            //Al iniciar el Form, almaceno su ancho, ya que lo voy a necesitar cambiar varias veces y necesito una referencia.
            this.formWidth = this.Width;

            //Busco en el Archivo de Configuración el estado con el que debe iniciar el Form.
            try
            {
                this.WindowState = File.getWindowsState();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        ///<summary>
        ///Propiedad sobrescrita para que cuando cambie el Text del Form también lo haga la etiqueta 
        ///Título.
        /// </summary>
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
        /// Obtiene el título de la Applicación, quitando la concatenación con el nombre del archivo reciente.
        /// </summary>
        /// <returns></returns>
        private string _getApplicationTitle()
        {
            string[] splitTitle = Text.Split('-');
            return splitTitle[0];
        }

        /// <summary>
        /// Abre un Form pasado por parámetro. Cierra todos los que se encuentran abiertos y carga el Form 
        /// al panel de Contenidos.
        /// </summary>
        /// <param name="child"></param>
        /// <param name="sender"></param>
        private void _openChildForm(object child, object sender)
        {
            //Convierto el Objeto que llamó a este método en su respectivo tipo para usarlo luego.
            MenuButton boton = sender as MenuButton;
             
            //Cargo todos los Forms abiertos en el Panel Contenido.
            List<Form> forms = panelContenido.Controls.OfType<Form>().ToList<Form>();

            //Esta variable la uso para chequear si cuando cierro un Form Estados, el archivo abierto
            //ha sido modificado. La seteo en OK ya que si no es un Form Estados pasa la validación.
            DialogResult checkOpenFile = DialogResult.OK;

            //Recorro los Forms abiertos para cerrarlos.
            foreach(Form formOpen in forms)
            {
                //Si esa un Form Estados el que estoy cerrando, me fijo si debe guardar el archivo actual.
                if (formOpen.GetType().Name == "FrmEstados") checkOpenFile = CheckUnsavedFile();
                //Si todo es OK, cierro el Form abierto.
                if(checkOpenFile == DialogResult.OK) formOpen.Close();
            }

            //Si pasa la validación del guardado del Archivo reciente, abro un nuevo Form pasado por parámetro
            if (checkOpenFile == DialogResult.OK)
            {
                //Desmarco todos los botones del Menú.
                _unselectMenuButtons();
                //Marco el botón actual.
                boton.Selected = true;

                //Remuevo el contenido del Panel Contenido.
                if (this.panelContenido.Controls.Count > 0)
                {
                    this.panelContenido.Controls.RemoveAt(0);
                }

                //Convierto ol Objeto child pasado por parámetro en un Form pra trabajarlo.
                Form form = child as Form;
                //Si el Form que abro no es un Form Estados seteo el Text del FrmMain con su text original
                //sin el nombre de ningún archivo.
                if (form.GetType().Name != "FrmEstados") this.Text = _getApplicationTitle();
                form.TopLevel = false;
                //Hago que el Form abierto llene todo el Panel Contenido.
                form.Dock = DockStyle.Fill;
                //Lo agrego al Panel.
                this.panelContenido.Controls.Add(form);
                this.panelContenido.Tag = form;
                form.Show(); //Finalmente lo muestro.
            }
            else
            {
                //Si no pasa la validación me quedo en el Form Estados hasta que se resuelva, por lo que 
                //su botón lo mantengo activo y seleccionado.
                btnEstados.Selected = true;
            }
        }

        /// <summary>
        /// Desmarca todos los Botones del Menú.
        /// </summary>
        private void _unselectMenuButtons()
        {
            foreach (Control control in this.panelMenu.Controls)
            {
                if(control is MenuButton)
                {
                    MenuButton button = control as MenuButton;
                    button.Selected = false;
                }
            }
        }

        /// <summary>
        /// Comprueba que un archivo abierto en un Form Estados no haya sido modificado.
        /// Si lo fue, pregunta si se desea guardar.
        /// </summary>
        /// <returns></returns>
        public DialogResult CheckUnsavedFile()
        {
            DialogResult resultSave = DialogResult.OK;

            //Como uso como bandera el '*' luego del nombre del archivo, pregunto si el último caracter
            //del Text del FrmMain es el mencionado. Si lo es, significa que el archivo ha sido modificado y no se
            //ha guardado.
            if (this.Text.Substring(this.Text.Length - 1, 1) == "*")
            {
                //Muestro mensaje que pregunta si se desea guardar el archivo y almaceno el resultado de ese mensaje 
                //en una variable.
                DialogResult result = MessageBox.Show("El archivo no se ha guardado ¿Desea guardarlo?", 
                    Application.ProductName, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //Trato de guardarlo con el método Save del Form Estados.
                    try
                    {
                        resultSave = this.formEstados.Save();
                    }
                    catch (Exception ex)
                    {
                        resultSave = DialogResult.Cancel;
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            //Devuelvo el desenlace para usarlo como validación posterior.
            return resultSave;
        }

        /**EVENTS**/
        
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

        private void btnStock_MouseClick(object sender, MouseEventArgs e)
        {
            _openChildForm(new FrmStock(), sender);
        }

        private void btnEstados_MouseClick(object sender, MouseEventArgs e)
        {
            this.formEstados = new FrmEstados(this);
            _openChildForm(this.formEstados, sender);
        }

        private void btnConfiguracion_MouseClick(object sender, MouseEventArgs e)
        {
            _openChildForm(new FrmConfiguracion(), sender);
        }

        private void panelDerecho_MouseMove(object sender, MouseEventArgs e)
        {
            //Hago que el Form se agrande en ancho cuando mantengo apretado el botón izquierdo del mouse.
            if (e.Button == MouseButtons.Left)
            {
                this.Size = new Size(this.PointToClient(MousePosition).X, this.Height);
            }
        }

        private void panelDerecho_MouseUp(object sender, MouseEventArgs e)
        {
            //Si el botón del mouse que suelto es el izquierdo almaceno el ancho del Form en la variable.
            if (e.Button == MouseButtons.Left)
            {
                this.formWidth = this.Width;
            }
        }

        private void panelInferior_MouseMove(object sender, MouseEventArgs e)
        {
            //Hago que el Form se agrande en alto cuando mantengo apretado el botón izquierdo del mouse.
            if (e.Button == MouseButtons.Left)
            {
                this.Size = new Size(this.Width, this.PointToClient(MousePosition).Y);
            }
        }

        private void panelEsquinaDerecha_MouseMove(object sender, MouseEventArgs e)
        {
            //Hago que el Form se agrande en ancho y alto cuando mantengo apretado el botón izquierdo del mouse.
            if (e.Button == MouseButtons.Left)
            {
                this.Size = new Size(this.PointToClient(MousePosition).X, this.PointToClient(MousePosition).Y);
            }
        }

        private void panelEsquinaDerecha_MouseUp(object sender, MouseEventArgs e)
        {
            //Si el botón del mouse que suelto es el izquierdo almaceno el ancho del Form en la variable.
            if (e.Button == MouseButtons.Left)
            {
                this.formWidth = this.Width;
            }
        }

        private void panelIzquierdo_MouseMove(object sender, MouseEventArgs e)
        {
            //Hago que el Form se agrande en ancho cuando mantengo apretado el botón izquierdo del mouse. Para hacer esto debo agrandar
            //el Form a medida que lo muevo a la izquierda.
            if (e.Button == MouseButtons.Left)
            {
                int mousePos = (int)this.PointToClient(MousePosition).X; //Tomo la Posición del mouse.
                int xPos = mousePos * (-1); //La invierto.
                int xWidth = xPos + this.formWidth; //Sumo esa nueva posición con el width almacenado. Obtengo el nuevo width.

                this.Size = new Size(xWidth, this.Height); //Cambio el tamaño del Form.
                this.formWidth = this.Width; //Guardo enseguida el ancho del mismo.

                //Si el ancho del Form es mayor al ancho mínimo permitido, muevo el form.
                if(this.formWidth > this.MinimumSize.Width) this.Location = new Point(this.Location.X - xPos, this.Location.Y);
            }
        }

        private void panelIzquierdo_MouseUp(object sender, MouseEventArgs e)
        {
            //Si el botón del mouse que suelto es el izquierdo almaceno el ancho del Form en la variable.
            if (e.Button == MouseButtons.Left)
            {
                this.formWidth = this.Width;
            }
        }

        private void panelEsquinaIzquierda_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int mousePos = (int)this.PointToClient(MousePosition).X; //Tomo la Posición del mouse.
                int xPos = mousePos * (-1); //La invierto.
                int xWidth = xPos + this.formWidth; //Sumo esa nueva posición con el width almacenado. Obtengo el nuevo width.

                this.Size = new Size(xWidth, this.PointToClient(MousePosition).Y); //Cambio el tamaño del Form.
                this.formWidth = this.Width; //Guardo enseguida el ancho del mismo.

                //Si el ancho del Form es mayor al ancho mínimo permitido, muevo el form.
                if (this.formWidth > this.MinimumSize.Width) this.Location = new Point(this.Location.X - xPos, this.Location.Y);
            }
        }

        private void panelEsquinaIzquierda_MouseUp(object sender, MouseEventArgs e)
        {
            //Si el botón del mouse que suelto es el izquierdo almaceno el ancho del Form en la variable.
            if (e.Button == MouseButtons.Left)
            {
                this.formWidth = this.Width;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (CheckUnsavedFile() == DialogResult.OK) Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea; //Esto se hace para que no se cubra el TaskBar.
                this.WindowState = FormWindowState.Maximized;

                //Quito los cursores de los bordes.
                this.panelIzquierdo.Cursor = Cursors.Default;
                this.panelEsquinaIzquierda.Cursor = Cursors.Default;
                this.panelInferior.Cursor = Cursors.Default;
                this.panelEsquinaDerecha.Cursor = Cursors.Default;
                this.panelDerecho.Cursor = Cursors.Default;

                this.btnMaximizar.Image = Resources.resume_windows; //Cambio el icono del Botón.

                //Guardo el Estado el Form en el Archivo de Configuración.
                try
                {
                    File.setWindowsState(FormWindowState.Maximized);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                this.WindowState = FormWindowState.Normal;

                //Asigno el cursor correspondiente a cada borde.
                this.panelIzquierdo.Cursor = Cursors.SizeWE;
                this.panelEsquinaIzquierda.Cursor = Cursors.SizeNESW;
                this.panelInferior.Cursor = Cursors.SizeNS;
                this.panelEsquinaDerecha.Cursor = Cursors.SizeNWSE;
                this.panelDerecho.Cursor = Cursors.SizeWE;

                this.btnMaximizar.Image = Resources.maximize_windows; //Cambio el icono del Botón.

                //Guardo el Estado el Form en el Archivo de Configuración.
                try
                {
                    File.setWindowsState(FormWindowState.Normal);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
