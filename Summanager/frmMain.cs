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


namespace Summanager
{
    public partial class FrmMain : Form
    {
        private FrmEstados formEstados;

        //DLLs necesarias para mover el Form.
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //DLL necesaria para redondear los bordes del Form.
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        ///<summary>
        ///Redondea los bordes del Form.
        /// </summary>
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public FrmMain()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));

            this.Text = Application.ProductName + " v" + Application.ProductVersion + "(Beta)";
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
        private void btnCerrar_MouseClick(object sender, MouseEventArgs e)
        {
            if(CheckUnsavedFile() == DialogResult.OK) Application.Exit();
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
    }
}
