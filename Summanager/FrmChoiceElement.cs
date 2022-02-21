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

            //Paso los suministros a elegir a una variable para mostrarlos en el DataGridView.
            this.suministros = suministros;

            //Creo un Nuevo Suministro Seleccionado.
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
                        //Cargo el DataGridView con todos los sumistros pasados uno a uno.
                        this.dgv.Rows.Add(suministro.Codigo, suministro.Nombre, suministro.Tipo.Nombre, suministro.GetModelosToString());
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
                //Hago esto en un Try por las dudas que ocurra algún error.
                //Obtengo en Índice de la Fila Seleccionada.
                int rowIndex = this.dgv.CurrentCell.RowIndex;
                //Busco con el Índice de la Fila Seleccionada el Código del Suministro.
                Int64 codigo = Convert.ToInt64(this.dgv.Rows[rowIndex].Cells["Codigo"].Value.ToString());

                //Busco en la Base de Datos el Suministro por su código y lo almaceno en la Propiedad Suministro Seleccionado, que la uso
                //para devolver el resultado de la selección.
                this.SuministroSeleccionado = DBSuministros.GetSuministro(codigo);
            }
            catch(Exception ex)
            {
                //Si hubo algún error, devuelvo Null y muestro mensaje de error.
                this.SuministroSeleccionado = null;

                MessageBox.Show(ex.Message, Application.ProductName + " " + Application.ProductVersion,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
            
            //Si todo transcurrió con normalidad, cierro el Formulario.
            this.Close();
        }

        private void dgv_KeyUp(object sender, KeyEventArgs e)
        {
            //Si la tecla que presiono en el DataGridView es ENTER, ejecuto el evento clic del Botón Elegir.
            if (e.KeyCode == Keys.Enter) btnElegir_Click(null, null);
        }

        private void FrmChoiceElement_Shown(object sender, EventArgs e)
        {
            //Cuando muestro el Formulario, pongo el Foco en el DataGridView.
            this.dgv.Focus();
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            //Con esto hago que se cancele la acción de pasar a la siguiente fila en el DataGridView al presionar la tecla ENTER. De esta manera
            //puedo usar esa tecla para que me ejecute el evento clic del Botón Elegir.
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }
    }
}
