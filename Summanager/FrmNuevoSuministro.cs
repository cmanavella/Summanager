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

            _cargarCombos(); //Cargo los Combos.
        }

        /// <summary>
        /// Carga los Combos tanto de Tipos como de Modelos con los datos obtenidos de la Base de Datos.
        /// </summary>
        private void _cargarCombos()
        {
            this.cmbTipo.Add(0, "-- Seleccione --"); //Agrego el campo Seleccione en el Combo Tipos.
            this.cmbModelos.Add(0, "-- Seleccione --"); //Agrego el campo Seleccione en el Combo Modelos.
            try
            {
                List<TipoSuministro> tipos = DBTiposSuministros.GetTipo(); //Traigo los tipos de la Base de Datos.
                List<Modelo> modelos = DBModelosImpresoras.GetModelo(); //Traigo los modelos de la Base de Datos.

                //Cargo el Combo Tipos.
                foreach(var tipo in tipos)
                {
                    this.cmbTipo.Add(tipo.Id, tipo.Nombre);
                }

                //Cargo el Combo Modelos.
                foreach (var modelo in modelos)
                {
                    this.cmbModelos.Add(modelo.Id, modelo.Nombre);
                }
            }
            catch(Exception ex)
            {
                //Si hubo un error, lo muestro.
                MessageBox.Show(ex.Message, Application.ProductName + " " + Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Busca en el DataGridView si el Id del elemento pasado por parámetro ya se encuentra en el mismo.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Valida que todos los campos del Formulario no tengan inconcistencias.
        /// </summary>
        /// <returns></returns>
        private bool _valido()
        {
            //Seto la variable de retorno en True, cosa que si no hay ningún error de validación esta siga manteniéndose en True.
            bool retorno = true;
            //Seteo el Mensaje de Validación como un String Vacío.
            this.msjeValidacion = String.Empty;

            //Valido.
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
            //Primero me fijo que en el Combo Modelos el elemento seleccionado no sea el Seleccione que tiene como Value 0.
            if(cmbModelos.SelectedItem().Value > 0)
            {
                //Me aseguro de el Modelo que quiero agregar al DataGridView no se encuentre en el mismo.
                if (!_existeElemento(cmbModelos.SelectedItem().Value))
                {
                    //Si el elemento no se encuentra ya agregado, lo agrego.
                    this.dgv.Rows.Add(cmbModelos.SelectedItem().Value, cmbModelos.SelectedItem().Text);

                    //Lo selecciono.
                    this.cmbModelos.SelectItem(0, true);

                    //Y habilito el Botón Quitar.
                    this.btnQuitar.Enabled = true;
                }
                else
                {
                    //Si existe el elemento aviso.
                    MessageBox.Show("El Modelo ya se encuentra cargado.", Application.ProductName + " " + Application.ProductVersion,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                //Si no se seleccionó ningun Modelo en el Combo, informo la situación.
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
            //Esto lo hago para que solo se puedan escribir números en el TextBox Código.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            //Esto es para que al presionar la tecla Enter pase al siguiente elemento del Formulario.
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.txtNombre.Focus();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Debo validar que los campos sean correctos.
            if (_valido())
            {
                MessageBox.Show("Guardo");
            }
            else
            {
                //Si no lo son, muestro un mensaje con los Errores de Validación.
                MessageBox.Show(this.msjeValidacion, Application.ProductName + " " + Application.ProductVersion,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtCodigo.Focus();
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            //Este botón quita el elemento seleccionado del DataGridView.

            //Como el DataGridView devuelve una colección de Filas pese a que solo puedo selecciónar una, debo quitar la fila (elemento) seleccionada
            //recorriendo esa colección con un Foreach.
            foreach (DataGridViewRow row in this.dgv.SelectedRows)
            {
                this.dgv.Rows.RemoveAt(row.Index);
            }

            //Si el contador de Filas del DataGridView llega a cero, desactivo el Botón Quitar.
            if(this.dgv.Rows.Count == 0) this.btnQuitar.Enabled = false;
        }
    }
}
