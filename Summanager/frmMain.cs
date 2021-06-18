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
using CustomControls;


namespace Summanager
{
    public partial class FrmMain : Form
    {
        private FrmEstados formEstados;

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

        public FrmMain()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
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

        private string _getApplicationTitle()
        {
            string[] splitTitle = Text.Split('-');
            return splitTitle[0];
        }

        private void _openChildForm(object child, object sender)
        {
            menuButton boton = sender as menuButton;
             
            List<Form> forms = panelContenido.Controls.OfType<Form>().ToList<Form>();
            DialogResult checkOpenFile = DialogResult.OK;

            foreach(Form formOpen in forms)
            {
                if (formOpen.GetType().Name == "frmEstados") checkOpenFile = _checkUnsavedFile();
                if(checkOpenFile == DialogResult.OK) formOpen.Close();
            }

            if (checkOpenFile == DialogResult.OK)
            {
                _unselectMenuButtons();
                boton.Selected = true;

                if (this.panelContenido.Controls.Count > 0)
                {
                    this.panelContenido.Controls.RemoveAt(0);
                }

                Form form = child as Form;
                if (form.GetType().Name != "frmEstados") this.Text = _getApplicationTitle();
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;
                this.panelContenido.Controls.Add(form);
                this.panelContenido.Tag = form;
                form.Show();
            }
            else
            {
                btnEstados.Selected = true;
            }
        }

        private void _unselectMenuButtons()
        {
            foreach (Control control in this.panelMenu.Controls)
            {
                if(control is menuButton)
                {
                    menuButton button = control as menuButton;
                    button.Selected = false;
                }
            }
        }

        private DialogResult _checkUnsavedFile()
        {
            DialogResult resultSave = DialogResult.OK;

            if (this.Text.Substring(this.Text.Length - 1, 1) == "*")
            {
                DialogResult result = MessageBox.Show("El archivo no se ha guardado ¿Desea guardarlo?", "SumManager", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        resultSave = this.formEstados.SaveAs();
                    }
                    catch (Exception ex)
                    {
                        resultSave = DialogResult.Cancel;
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            return resultSave;
        }

        /**EVENTS**/
        private void btnCerrar_MouseClick(object sender, MouseEventArgs e)
        {
            if(_checkUnsavedFile() == DialogResult.OK) Application.Exit();
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
