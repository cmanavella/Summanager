using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Data;

namespace Summanager
{
    public partial class FrmNuevoSuministro : Summanager.FrmAbm
    {
        private string msjeValidacion;
        public FrmNuevoSuministro(string titulo) : base(titulo)
        {
            InitializeComponent();

            _cargarCombos();
        }

        private void _cargarCombos()
        {
            this.cmbTipo.Add(0, "-- Seleccione --");
            this.cmbModelos.Add(0, "-- Seleccione --");
            try
            {
                List<TipoSuministro> tipos = DBTiposSuministros.GetTipos();
                List<Modelo> modelos = DBModelosImpresoras.GetModelos();

                foreach(var tipo in tipos)
                {
                    this.cmbTipo.Add(tipo.Id, tipo.Nombre);
                }

                foreach (var modelo in modelos)
                {
                    this.cmbModelos.Add(modelo.Id, modelo.Nombre);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName + " " + Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool _existeElemento(int value)
        {
            bool retorno = false;

            if (this.dgv.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in this.dgv.Rows)
                {
                    int id = Convert.ToInt32(fila.Cells["Id"].Value.ToString());
                    retorno = id == value;
                }
            }

            return retorno;
        }

        private bool _valido()
        {
            bool retorno = true;
            this.msjeValidacion = String.Empty;

            if (this.txtCodigo.IsMaskared) {
                if(retorno) retorno = false;
                this.msjeValidacion += "- El campo 'Código' es obligatorio.";
            }
            if (this.txtNombre.IsMaskared)
            {
                if (retorno) retorno = false;
                if (this.msjeValidacion.Length > 0) this.msjeValidacion += "\n";
                this.msjeValidacion += "- El campo 'Nombre' es obligatorio.";
            }
            if (this.cmbTipo.SelectedItem().Value == 0)
            {
                if (retorno) retorno = false;
                if (this.msjeValidacion.Length > 0) this.msjeValidacion += "\n";
                this.msjeValidacion += "- El campo 'Tipo' es obligatorio.";
            }
            if (this.dgv.Rows.Count == 0)
            {
                if (retorno) retorno = false;
                if (this.msjeValidacion.Length > 0) this.msjeValidacion += "\n";
                this.msjeValidacion += "- El campo 'Compatible con' es obligatorio. Debe agregar al menos un 'Modelo'.";
            }

            return retorno;
        }

        /**EVENTOS**/

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(cmbModelos.SelectedItem().Value > 0)
            {
                if (!_existeElemento(cmbModelos.SelectedItem().Value))
                {
                    this.dgv.Rows.Add(cmbModelos.SelectedItem().Value, cmbModelos.SelectedItem().Text);

                    this.cmbModelos.SelectItem(0, true);
                }
                else
                {
                    MessageBox.Show("El Modelo ya se encuentra cargado.", Application.ProductName + " " + Application.ProductVersion,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Modelo de Impresora para poder agregarla.", Application.ProductName + " " + Application.ProductVersion, 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            //Debo comprobar que al salir del control el suministro no exista, siempre que el Textbox tenga contenido.
            if (!this.txtCodigo.IsMaskared && this.txtCodigo.Text.Length > 0)
            {
                Suministro suministro = DBSuministros.GetSuministro(Convert.ToInt64(this.txtCodigo.Text));

                if (suministro != null)
                {
                    this.txtCodigo.Focus();
                    MessageBox.Show("El suministro ya existe.", Application.ProductName + " " + Application.ProductVersion,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.txtNombre.Focus();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_valido())
            {
                MessageBox.Show("Guardo");
            }
            else
            {
                MessageBox.Show(this.msjeValidacion, Application.ProductName + " " + Application.ProductVersion,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtCodigo.Focus();
            }
        }
    }
}
