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
    }
}
