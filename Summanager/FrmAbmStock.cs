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

        public FrmAbmStock() : this(String.Empty) { }

        public FrmAbmStock(string title)
        {
            InitializeComponent();
            this.lblTitulo.Text = title;
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

            if (result == DialogResult.Yes) this.Close();
        }

        private void txtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            if(e != null)
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    //this.txtCantidad.Focus();
                    MessageBox.Show("Hola Mundo");
                }
            }
        }

        private void txtBusqueda_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
            }
        }
    }
}
