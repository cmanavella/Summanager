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
    public partial class frmMain : Form
    {
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

        private void _openChildForm(object child)
        {
            List<Form> forms = panelContenido.Controls.OfType<Form>().ToList<Form>();

            foreach(Form formOpen in forms)
            {
                formOpen.Close();
            }

            if (this.panelContenido.Controls.Count > 0)
            {
                this.panelContenido.Controls.RemoveAt(0);
            }

            Form form = child as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panelContenido.Controls.Add(form);
            this.panelContenido.Tag = form;
            form.Show();
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

        /**EVENTS**/
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

        private void btnStock_MouseClick(object sender, MouseEventArgs e)
        {
            _unselectMenuButtons();
            btnStock.Selected = true;
            _openChildForm(new frmStock());
        }

        private void btnImpresoras_MouseClick(object sender, MouseEventArgs e)
        {
            _unselectMenuButtons();
            btnEstados.Selected = true;
            _openChildForm(new frmEstados(this));
        }

        private void btnConfiguracion_MouseClick(object sender, MouseEventArgs e)
        {
            _unselectMenuButtons();
            btnConfiguracion.Selected = true;
            _openChildForm(new frmConfiguracion());
        }
    }
}
