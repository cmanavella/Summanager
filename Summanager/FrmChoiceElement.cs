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
    public partial class FrmChoiceElement : Form
    {
        //DLLs necesarias para mover el Form.
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private List<Suministro> suministros;

        public Suministro SuministroSeleccionado;

        public FrmChoiceElement(List<Suministro> suministros)
        {
            InitializeComponent();
            this.lblTitulo.Text = "Elegir elemento";

            this.suministros = suministros;

            this.SuministroSeleccionado = new Suministro();
        }

        /// <summary>
        /// Carga el DataGridView con una lista de suministros.
        /// </summary>
        private void _loadDgv()
        {
            if (this.suministros != null)
            {
                if (this.suministros.Count > 0)
                {
                    foreach(Suministro suministro in this.suministros)
                    {
                        this.dgv.Rows.Add(suministro.Codigo, suministro.Nombre);
                    }
                }
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea Cancelar la operación?", Application.ProductName + " " + Application.ProductVersion,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                this.SuministroSeleccionado = null;
                this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            btnCancelar_Click(null, null);
        }

        private void FrmChoiceElement_Load(object sender, EventArgs e)
        {
            _loadDgv();
        }

        private void btnElegir_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = this.dgv.CurrentCell.RowIndex;
                Int64 codigo = Convert.ToInt64(this.dgv.Rows[rowIndex].Cells["Codigo"].Value.ToString());

                this.SuministroSeleccionado = DBSuministros.GetSuministro(codigo);
            }
            catch(Exception ex)
            {
                this.SuministroSeleccionado = null;

                MessageBox.Show(ex.Message, Application.ProductName + " " + Application.ProductVersion,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
            

            this.Close();
        }
    }
}
